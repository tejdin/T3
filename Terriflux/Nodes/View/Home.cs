using Godot;
using System;
using System.Threading.Tasks;
using Terriflux.Programs.GameContext;

namespace Terriflux.Programs.View {
    public partial class Home : StandardWindow
    {
        private Label _loginLabel;
        private Label _passwordLabel;

        private bool loginAnim_finished = false;
        private bool loginAnim_working = false;
        private bool passwordAnim_finished = false;
        private bool passwordAnim_working = false;
        private bool wantToStart = false;

        public Home() { }

        public override void _Ready()
        {
            base._Ready();

            _loginLabel = GetNode<Label>("LoginBackground/LoginType");
            _passwordLabel = GetNode<Label>("PasswordBackground/PasswordType");
        }

        public override void _Process(double delta)
        {
            if (wantToStart)
            {
                // start animations
                if (!loginAnim_finished && !loginAnim_working)
                {
                    LoginAnim();
                    loginAnim_working = true;
                }
                else if (loginAnim_finished && !passwordAnim_finished && !passwordAnim_working)
                {
                    PasswordAnim();
                    passwordAnim_working = true;
                }
                // all finished?
                else if (loginAnim_finished && passwordAnim_finished)
                {
                    // wait 2 seconds...
                    WaitTime(2);

                    // then start the game
                    GetTree().Root.AddChild(GD.Load<PackedScene>(OurPaths.VIEW_NODES + "MainScene" + OurPaths.NODEXT).Instantiate());
                }
            }
        }

        private async void LoginAnim()
        {
            _loginLabel.Text = "M";

            await Task.Delay(200); // Attendre 0.2 secondes

            _loginLabel.Text += "a";
            await Task.Delay(200);
            _loginLabel.Text += "y";
            await Task.Delay(200);
            _loginLabel.Text += "o";
            await Task.Delay(200);
            _loginLabel.Text += "r";
            await Task.Delay(200);
            _loginLabel.Text += " x";
            await Task.Delay(200);
            _loginLabel.Text += "x";
            await Task.Delay(200);
            _loginLabel.Text += "x";

            this.loginAnim_finished = true;
        }

        private async void PasswordAnim()
        {
            for (int i = 0; i < 5; i++)
            {
                _passwordLabel.Text += "*";
                await Task.Delay(200);
            }

            this.passwordAnim_finished = true;
        }

        private static async void WaitTime(int seconds)
        {
            await Task.Delay(seconds);
        }


        /// <summary>
        /// Call for animations then start game
        /// </summary>
        private void OnStartPressed()
        {
            wantToStart = true;
        }

        private void OnExitGamePressed()
        {
            GetTree().Quit();
        }
    }
}