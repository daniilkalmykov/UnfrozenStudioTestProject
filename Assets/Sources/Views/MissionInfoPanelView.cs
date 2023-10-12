using Sources.MissionsSystem;
using TMPro;
using UnityEngine;

namespace Sources.Views
{
    internal sealed class MissionInfoPanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _description;

        public void Set(IMission mission)
        {
            _name.text = mission.Name;
            _description.text = mission.Description;
        }
    }
}