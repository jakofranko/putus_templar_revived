using System;
using System.Collections.Generic;
using System.Text;
using Qud.API;
using XRL;
using XRL.Core;
using XRL.Messages;
using XRL.UI;
using XRL.World;
using XRL.World.AI.GoalHandlers;
using XRL.World.Capabilities;
using XRL.World.Conversations;
using XRL.World.Effects;
using XRL.World.Parts;

namespace PutusTemplarRevived.Dialogue.ChoosePath
{
    public class BecomeGunnerKnightTemplar : IConversationPart
    {
        public string Target = "End";

        public override bool WantEvent(int ID, int Propagation)
        {
            return base.WantEvent(ID, Propagation)
                   || ID == IsElementVisibleEvent.ID
                   || ID == GetChoiceTagEvent.ID
                   || ID == GetTargetElementEvent.ID
                ;
        }

        public override bool HandleEvent(IsElementVisibleEvent E)
        {
            var player = The.Player;
            var isTemplar = player.GetPropertyOrTag("BecameGunnerKnightTemplar");
            XRL.Messages.MessageQueue.AddPlayerMessage(isTemplar);
            if (isTemplar == "true") return false;

            return base.HandleEvent(E);
        }

        public override bool HandleEvent(GetTargetElementEvent E)
        {
            var player = The.Player;
            var isTemplar = player.GetPropertyOrTag("BecameGunnerKnightTemplar");
            XRL.Messages.MessageQueue.AddPlayerMessage(isTemplar);

            if (isTemplar == "true")
            {
                Popup.Show("You have already chosen the path of the Knight Templar.");
                E.Target = "Start";
            }
            else
            {
                Popup.Show("Embued with a higher rank, you take on the mantle of a Kight Templar");
                JournalAPI.AddAccomplishment(
                    "You became a Gunner-Knight Templar.",
                    "On the " + Calendar.getDay() + " of " + Calendar.getMonth() + ", in the year " + Calendar.getYear().ToString() + " AR, =name= took on greater oaths and became a Templar Knight of the Order of the Cannon.",
                    muralCategory: JournalAccomplishment.MuralCategory.BodyExperienceNeutral,
                    muralWeight: JournalAccomplishment.MuralWeight.VeryHigh
                );

                player.pRender.Tile = "Creatures/sw_templar_gunner_flipped.bmp";
                player.SetStringProperty("BecameGunnerKnightTemplar", "true");
            }

            return base.HandleEvent(E);
        }

        public override bool HandleEvent(GetChoiceTagEvent E)
        {
            E.Tag = "{{R|[choose path]}}";
            return base.HandleEvent(E);
        }
    }
}
