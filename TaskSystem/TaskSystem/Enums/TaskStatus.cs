using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TaskStatus
    {
        [Description("To Do")]
        Todo = 1,
        [Description("Doing")]
        Doing = 2,
        [Description("Done")]
        Done = 3
    }
}
