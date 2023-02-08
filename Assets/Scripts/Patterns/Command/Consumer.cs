using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Command
{

    public class Consumer : MonoBehaviour
    {
        private List<ICommand> _commandsKey1;
        private List<ICommand> _commandsKey2;

        public void Configure(List<ICommand> commandsKey1, List<ICommand> commandsKey2)
        {
            _commandsKey1 = commandsKey1;
            _commandsKey2 = commandsKey2;
        }

        private void Update()
        {
            CommandQueue commandQueue = CommandQueue.Instance;

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                foreach(ICommand command in _commandsKey1)
                {
                    commandQueue.AddCommand(command);
                }
            }

            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                foreach (ICommand command in _commandsKey2)
                {
                    commandQueue.AddCommand(command);
                }
            }
        }
    }
}
