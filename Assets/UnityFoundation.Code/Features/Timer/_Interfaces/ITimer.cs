namespace UnityFoundation.Code.Timer
{
    public interface ITimer
    {
        bool Completed { get; }
        float Completion { get; }
        float CurrentTime { get; }
        bool IsRunning { get; }
        float RemainingTime { get; }
        float TotalTime { get; }

        void Close();
        ITimer Loop();
        void Resume();
        ITimer RunOnce();
        ITimer SetTotalTime(float newAmount);
        ITimer SetName(string name);
        ITimer Start();
        void Stop();
    }
}