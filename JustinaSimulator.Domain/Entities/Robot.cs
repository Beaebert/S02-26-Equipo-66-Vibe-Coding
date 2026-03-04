using JustinaSimulator.Domain.Enums;
using System.Collections.Generic;

namespace JustinaSimulator.Domain.Entities;

public class Robot
{
    public Guid Id { get; private set; }
    public Coordinate CurrentTarget { get; private set; }
    public List<Coordinate> Trajectory { get; private set; }
    public SafetyStatus CurrentStatus { get; private set; }

    // Session Data
    public DateTime SessionDate { get; private set; }
    public string DoctorName { get; private set; }

    // Metrics
    public int WarningsCount { get; private set; }
    public int DangersCount { get; private set; }
    public double TotalDistance { get; private set; }
    public int FailedClicks { get; private set; }
    public int TotalDurationSeconds { get; private set; }

    // Safety Zone mapped to Blazor UI (Center at X:40, Y:25)
    // Safe radius = 7, Warning radius = 13

    // EF Core requires a parameterless constructor
    private Robot()
    {
        CurrentTarget = Coordinate.Origin;
        Trajectory = new();
        DoctorName = string.Empty;
    }

    public Robot(Guid id, string doctorName = "Dr. Juan Pérez")
    {
        Id = id;
        CurrentTarget = Coordinate.Origin;
        Trajectory = new List<Coordinate>();
        Trajectory.Add(CurrentTarget);
        CurrentStatus = SafetyStatus.Safe;

        SessionDate = DateTime.Now;
        DoctorName = doctorName;
        WarningsCount = 0;
        DangersCount = 0;
        TotalDistance = 0;
        FailedClicks = 0;
        TotalDurationSeconds = 0;
    }

    public void MoveTo(Coordinate newTarget)
    {
        // Calculate distance payload
        double dx = newTarget.X - CurrentTarget.X;
        double dy = newTarget.Y - CurrentTarget.Y;
        TotalDistance += Math.Sqrt(dx * dx + dy * dy);

        CurrentTarget = newTarget;
        Trajectory.Add(newTarget);

        // Update status during movement
        var newStatus = CalculateSafetyZone(newTarget);

        // Only increment counters if the status is changing to a worse state during movement
        if (newStatus == SafetyStatus.Warning && CurrentStatus == SafetyStatus.Safe) WarningsCount++;
        if (newStatus == SafetyStatus.Danger && CurrentStatus != SafetyStatus.Danger) DangersCount++;

        CurrentStatus = newStatus;
    }

    public void Click()
    {
        // Update status for the click action
        var actionStatus = CalculateSafetyZone(CurrentTarget);

        // Every click outside the safe zone strictly penalizes
        if (actionStatus == SafetyStatus.Warning)
        {
            WarningsCount++;
            FailedClicks++;
        }
        if (actionStatus == SafetyStatus.Danger)
        {
            DangersCount++;
            FailedClicks++;
        }

        CurrentStatus = actionStatus;
    }

    private SafetyStatus CalculateSafetyZone(Coordinate c)
    {
        // Safe Zone mapped to Blazor UI (Center at X:40, Y:25)
        // because the UI box is 800x500 px. Mouse coordinates are divided by 10.
        double dx = c.X - 40.0;
        double dy = c.Y - 25.0;
        double distance = Math.Sqrt(dx * dx + dy * dy);

        if (distance <= 7.0) return SafetyStatus.Safe;
        if (distance <= 13.0) return SafetyStatus.Warning;
        return SafetyStatus.Danger;
    }

    public void EndSession(int durationSeconds)
    {
        TotalDurationSeconds = durationSeconds;
    }
}
