using Sources.CharactersSystem;

namespace Sources.CompositeRoot
{
    internal sealed class PlayerCompositeRoot : CompositeRoot
    {
        private Character _character;
        public ICharacter Character => _character;

        public override void Compose()
        {
            _character = new Character();

            //Init heroes from xml
        }
    }
}