namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerProgress : IUiListener
    {
        void SetProgressPercent(int percent);
        void ProgressStarted();
        void ProgressFinished();
        
    }
}
