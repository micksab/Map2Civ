namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerModel : IUiListener
    {
        void ModelChanged();

        void UpdateCurrentModelFile(string fileName);
    }
}