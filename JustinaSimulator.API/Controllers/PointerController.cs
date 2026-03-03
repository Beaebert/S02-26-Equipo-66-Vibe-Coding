using JustinaSimulator.Application.UseCases.MovePointer;
using JustinaSimulator.Application.UseCases.Click;
using JustinaSimulator.Domain.Enums;
using JustinaSimulator.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JustinaSimulator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PointerController : ControllerBase
{
    private readonly MovePointerHandler _moveHandler;
    private readonly ClickHandler _clickHandler;

    public PointerController(MovePointerHandler moveHandler, ClickHandler clickHandler)
    {
        _moveHandler = moveHandler;
        _clickHandler = clickHandler;
    }

    [HttpPost("move")]
    public async Task<IActionResult> MovePointer([FromBody] MovePointerCommand command)
    {
        await _moveHandler.HandleAsync(command);
        return Ok(new { Message = "Pointer moved", Target = command });
    }

    [HttpPost("click")]
    public async Task<IActionResult> Click([FromBody] ClickCommand command)
    {
        var status = await _clickHandler.HandleAsync(command);

        var message = status == SafetyStatus.Safe
            ? "Operation Successful"
            : "Critical Error: Operation out of safe zone";

        return Ok(new { Message = message, Status = status, Target = command });
    }

    [HttpPost("start")]
    public async Task<IActionResult> StartSession([FromQuery] string doctorName, [FromServices] ISimulationStateRepository repository)
    {
        var name = string.IsNullOrEmpty(doctorName) ? "Dr. Juan Pérez" : doctorName;
        var session = await repository.CreateNewSessionAsync(name);
        return Ok(new { Message = "Session Started", SessionId = session.Id, DoctorName = session.DoctorName, Date = session.SessionDate });
    }

    [HttpGet("results")]
    public async Task<IActionResult> GetResults([FromServices] ISimulationStateRepository repository)
    {
        var session = await repository.GetLatestSessionAsync();
        return Ok(new
        {
            WarningsCount = session.WarningsCount,
            DangersCount = session.DangersCount,
            DoctorName = session.DoctorName,
            SessionDate = session.SessionDate,
            TotalDistance = session.TotalDistance,
            FailedClicks = session.FailedClicks,
            TotalDurationSeconds = session.TotalDurationSeconds
        });
    }

    [HttpPost("end")]
    public async Task<IActionResult> EndSession([FromQuery] int durationSeconds, [FromServices] ISimulationStateRepository repository)
    {
        var session = await repository.GetLatestSessionAsync();
        session.EndSession(durationSeconds);
        await repository.UpdateRobotAsync(session);
        return Ok(new { Message = "Session Ended" });
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetHistory([FromServices] ISimulationStateRepository repository)
    {
        var session = await repository.GetLatestSessionAsync();
        return Ok(session.Trajectory);
    }
}
