using JustinaSimulator.Application.Interfaces;
using JustinaSimulator.Domain.Entities;
using System.Threading.Tasks;

namespace JustinaSimulator.Application.UseCases.MovePointer;

public class MovePointerHandler
{
    private readonly ISimulationStateRepository _repository;

    public MovePointerHandler(ISimulationStateRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(MovePointerCommand command)
    {
        // 1. Get current state
        var robot = await _repository.GetLatestSessionAsync();

        // 2. Create new target coordinate
        var newTarget = new Coordinate(command.X, command.Y, command.Z);

        // 3. Update domain entity logic
        robot.MoveTo(newTarget);

        // 4. Persist changes
        await _repository.UpdateRobotAsync(robot);
    }
}
