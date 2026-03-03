using JustinaSimulator.Application.Interfaces;
using JustinaSimulator.Domain.Entities;
using JustinaSimulator.Domain.Enums;
using System.Threading.Tasks;

namespace JustinaSimulator.Application.UseCases.Click;

public class ClickHandler
{
    private readonly ISimulationStateRepository _repository;

    public ClickHandler(ISimulationStateRepository repository)
    {
        _repository = repository;
    }

    public async Task<SafetyStatus> HandleAsync(ClickCommand command)
    {
        var robot = await _repository.GetLatestSessionAsync();

        // Ensure robot is at the click location (optional, but good for consistency)
        var target = new Coordinate(command.X, command.Y, command.Z);
        robot.MoveTo(target);

        // Perform Click Action
        robot.Click();

        await _repository.UpdateRobotAsync(robot);

        return robot.CurrentStatus;
    }
}
