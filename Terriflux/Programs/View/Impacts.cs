using Godot;
using Terriflux.Programs.GameContext;

namespace Terriflux.Programs.Gauges
{
    public partial class Impacts : Control
    {
        private IGauge _social;
        private IGauge _economy;
        private IGauge _ecology;

        protected Impacts() { }

        public static Impacts Design()
        {
            return GD.Load<PackedScene>(OurPaths.VIEW_NODES + "Impacts.tscn").Instantiate<Impacts>();
        }

        public override void _Ready()
        {
            base._Ready();

            _social = GetNode<IGauge>("SocialGauge");
            _economy = GetNode<IGauge>("EconomyGauge");
            _ecology = GetNode<IGauge>("EcologyGauge");
        }

        public void AddSocial(double newValue)
        {
            _social.SetValue(_social.GetValue() + newValue);
        }

        public void AddEconomy(double newValue)
        {
            _economy.SetValue(_economy.GetValue() + newValue);
        }

        public void AddEcology(double newValue)
        {
            _ecology.SetValue(_ecology.GetValue() + newValue);
        }

        /// <returns>Social, Economy, Ecology</returns>
        public double[] GetImpacts()
        {
            return new double[] { _social.GetValue(), _economy.GetValue(), _ecology.GetValue() };
        }
    }
}