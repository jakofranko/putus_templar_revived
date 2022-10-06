using XRL;
using XRL.Core;
using XRL.Messages;
using XRL.World.Conversations;

namespace PutusTemplarRevived.Dialogue
{
    [HasConversationDelegate]
    public static class Delegates
    {
        [ConversationDelegate]
        public static bool IfChosenPath(DelegateContext Context)
        {
            var isTemplar = Context.Target.GetPropertyOrTag("BecameKnightTemplar");
            var isGunnerTemplar = Context.Target.GetPropertyOrTag("BecameGunnerKnightTemplar");
            var isNewfather = Context.Target.GetPropertyOrTag("BecameNewfather");

            return isTemplar != "true" && isGunnerTemplar != "true" && isNewfather != "true";
        }
    }
}
