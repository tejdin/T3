using Godot;

namespace Terriflux.Programs
{
    public interface IRound
    {
        /// <returns>The round number.</returns>
        int GetNumber();

        /// <summary>
        /// Go to next turn.
        /// </summary>
        void Next();
    }
}