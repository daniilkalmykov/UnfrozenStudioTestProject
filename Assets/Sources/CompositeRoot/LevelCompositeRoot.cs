using Sources.LevelsSystem;

namespace Sources.CompositeRoot
{
    internal sealed class LevelCompositeRoot : CompositeRoot
    {
        private Level _level;

        public ILevel Level => _level;
        
        public override void Compose()
        {
            _level = new Level();
        }
    }
}