using System;
using System.Collections.Generic;

namespace TheOtherRolesEdited.Modules
{
    internal class LateTask
    {
        private static readonly List<LateTask> Tasks = [];
        private readonly Action action;
        private readonly string name;
        private float timer;

        public LateTask(Action action, float time, string name = "No Name Task")
        {
            this.action = action;
            timer = time;
            this.name = name;
            Tasks.Add(this);
        }
    }
}