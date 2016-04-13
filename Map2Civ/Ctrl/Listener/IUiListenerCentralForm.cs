using System;

namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerCentralForm : IUiListener
    {
        void UpdateAssignedPercentComplete();

        void PublishNewInfoMessage(string infoMessage);

        void SetModelButtonAndMenusEnabledState(Boolean saveActive, Boolean saveAsActive);
    }
}