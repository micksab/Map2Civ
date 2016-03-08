using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationModel;

using System;

namespace Map2CivilizationCtrl.Listener
{
    public interface IUiListenerCentralForm : IUiListener
    {
        void UpdateAssignedPercentComplete();
        void PublishNewInfoMessage(String infoMessage);
        void SetModelButtonAndMenusEnabledState(Boolean saveActive, Boolean saveAsActive);


    }
}
