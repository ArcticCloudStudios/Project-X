using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arctic.Keybinds
{
    public class KeybindingManager : MonoBehaviour
    {
        private List<string> keys;
        public List<Dropdown> Dropdowns = new List<Dropdown>();

        //Key Variables
        public KeyCode WalkForward;
        public KeyCode WalkBackward;
        public KeyCode WalkRight;
        public KeyCode WalkLeft;
        public KeyCode JumpKey;
        public KeyCode Crouch;
        public KeyCode Sprint;
        public KeyCode Fire;
        public KeyCode Aim;
        public KeyCode PauseKey;
        public KeyCode InventoryKey;
        public KeyCode _DevMode;
        public KeyCode Interact;

        public void Start()
        {

            keys = new List<string> { };
            foreach (string s in System.Enum.GetNames(typeof(KeyCode)))
            {
                //print(s);
                keys.Add(s);
            }

            for (int i = 0; i < Dropdowns.Count; i++)
            {
                Dropdowns[i].AddOptions(keys);
            }
            loadPrefabs();

        }

        private void loadPrefabs()
        {
            JumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpPrefs"));
            SelectKey(Dropdowns[0], JumpKey.ToString());

            WalkForward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("walkfPrefs"));
            SelectKey(Dropdowns[1], WalkForward.ToString());

            WalkBackward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("walkbPrefs"));
            SelectKey(Dropdowns[2], WalkBackward.ToString());

            WalkRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("walkrPrefs"));
            SelectKey(Dropdowns[3], WalkRight.ToString());

            WalkLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("walklPrefs"));
            SelectKey(Dropdowns[4], WalkLeft.ToString());

            Crouch = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("crouchPrefs"));
            SelectKey(Dropdowns[5], Crouch.ToString());

            Sprint = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("sprintPrefs"));
            SelectKey(Dropdowns[6], Sprint.ToString());

            _DevMode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("devmodePrefs"));
            SelectKey(Dropdowns[7], _DevMode.ToString());

            Interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("interactPrefs"));
            SelectKey(Dropdowns[8], Interact.ToString());

            Fire = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("firePrefs"));
            SelectKey(Dropdowns[9], Fire.ToString());

            Aim = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("aimPrefs"));
            SelectKey(Dropdowns[10], Aim.ToString());

            PauseKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pausePrefs"));
            SelectKey(Dropdowns[11], PauseKey.ToString());

            InventoryKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("inventoryPrefs"));
            SelectKey(Dropdowns[10], InventoryKey.ToString());



        }

        private void SelectKey(Dropdown _dropDown, string _s)
        {
            for (int i = 0; i < keys.Count; i++) //Loops through the key list.
            {
                if (_s == keys[i])
                {
                    _dropDown.value = i;
                }
            }
        }

        //CHANGE KEYS
        public void ChangeJumpKey(int id)
        {
            JumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("jumpPrefs", keys[id]);
        }
        public void ChangeInteractKey(int id)
        {
            Interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("interactPrefs", keys[id]);
        }
        public void ChangeWalkFKey(int id)
        {
            WalkForward = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("walkfPrefs", keys[id]);
        }
        public void ChangeWalkBKey(int id)
        {
            WalkBackward = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("walkbPrefs", keys[id]);
        }
        public void ChangeWalkRKey(int id)
        {
            WalkRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("walkrPrefs", keys[id]);
        }
        public void ChangeWalkLKey(int id)
        {
            WalkLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("walklPrefs", keys[id]);
        }
        public void ChangeCrouchKey(int id)
        {
            Crouch = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("crouchPrefs", keys[id]);
        }
        public void ChangeSprintKey(int id)
        {
            Sprint = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("sprintPrefs", keys[id]);
        }
        public void ChangeFireKey(int id)
        {
            Fire = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("firePrefs", keys[id]);
        }
        public void ChangeAimKey(int id)
        {
            Aim = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("aimPrefs", keys[id]);
        }
        public void ChangePauseKey(int id)
        {
            PauseKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("pausePrefs", keys[id]);
        }
        public void ChangeInventoryKey(int id)
        {
            InventoryKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("inventoryPrefs", keys[id]);
        }
        public void ChangeDevModeKey(int id)
        {
            _DevMode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("devmodePrefs", keys[id]);
        }
    }
}
