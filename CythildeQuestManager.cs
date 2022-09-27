using System;
using System.Collections.Generic;
using System.Text;
using XRL.World.QuestManagers;
using XRL.World.Parts;
using XRL.World;

namespace XRL.World.QuestManagers
{
    [Serializable]
    class BringCythildeAnArtifact : QuestManager
    {
        public override void OnQuestAdded()
        {
            Inventory pInventory = XRL.Core.XRLCore.Core.Game.Player.Body.GetPart("Inventory") as Inventory;

            foreach (GameObject GO in pInventory.GetObjects())
            {
                if (GO.HasPart("Examiner"))
                {
                    Examiner pExaminer = GO.GetPart("Examiner") as Examiner;
                    if (pExaminer.Complexity > 0)
                    {
                        XRL.Core.XRLCore.Core.Game.FinishQuestStep("Fetch Cythilde an Artifact", "Find an Artifact");
                    }
                }
            }

            this.Name = "QMBringCythildeAnArtifact";
            XRL.Core.XRLCore.Core.Game.Player.Body.AddPart(this);
            XRL.Core.XRLCore.Core.Game.Player.Body.RegisterPartEvent(this, "Took");
        }

        public override void OnQuestComplete()
        {
            XRL.Core.XRLCore.Core.Game.Player.Body.RemovePart(this);
        }

        public override bool FireEvent(Event E)
        {
            if (E.ID == "Took")
            {
                GameObject GO = E.GetParameter("Object") as GameObject;
                if (GO.HasPart("Examiner"))
                {
                    if ((GO.GetPart("Examiner") as Examiner).Complexity > 0)
                    {
                        XRL.Core.XRLCore.Core.Game.FinishQuestStep("Fetch Cythilde an Artifact", "Find an Artifact");
                    }
                }
            }

            return true;
        }
    }

    [Serializable]
    class BringCythildeAnotherArtifact : QuestManager
    {
        public override void OnQuestAdded()
        {
            Inventory pInventory = XRL.Core.XRLCore.Core.Game.Player.Body.GetPart("Inventory") as Inventory;

            foreach (GameObject GO in pInventory.GetObjects())
            {
                if (GO.HasPart("Examiner"))
                {
                    Examiner pExaminer = GO.GetPart("Examiner") as Examiner;
                    if (pExaminer.Complexity > 0)
                    {
                        XRL.Core.XRLCore.Core.Game.FinishQuestStep("Fetch Cythilde Another Artifact", "Find Another Artifact");
                    }
                }
            }

            this.Name = "QMBringCythildeAnotherArtifact";
            XRL.Core.XRLCore.Core.Game.Player.Body.AddPart(this);
            XRL.Core.XRLCore.Core.Game.Player.Body.RegisterPartEvent(this, "Took");
        }

        public override void OnQuestComplete()
        {
            XRL.Core.XRLCore.Core.Game.Player.Body.RemovePart(this);
        }

        public override bool FireEvent(Event E)
        {
            if (E.ID == "Took")
            {
                GameObject GO = E.GetParameter("Object") as GameObject;
                if (GO.HasPart("Examiner"))
                {
                    if ((GO.GetPart("Examiner") as Examiner).Complexity > 0)
                    {
                        XRL.Core.XRLCore.Core.Game.FinishQuestStep("Fetch Cythilde Another Artifact", "Find Another Artifact");
                    }
                }
            }

            return true;
        }
    }

    [Serializable]
    class BringCythildeWire : QuestManager
    {
        public int nTotalLength = 0;
        public override void OnQuestAdded()
        {
            Inventory pInventory = XRL.Core.XRLCore.Core.Game.Player.Body.GetPart("Inventory") as Inventory;

            nTotalLength = 0;
            foreach (GameObject GO in pInventory.GetObjects())
            {
                if (GO.HasPart("Wire"))
                {
                    Wire pWire = GO.GetPart("Wire") as Wire;
                    nTotalLength += pWire.Length;
                }
            }

            if (nTotalLength >= 200)
            {
                XRL.Core.XRLCore.Core.Game.FinishQuestStep("Finishing the Conduit", "Find 200 feet of copper wire");
            }

            this.Name = "QMBringCythildeWire";
            XRL.Core.XRLCore.Core.Game.Player.Body.AddPart(this);
            XRL.Core.XRLCore.Core.Game.Player.Body.RegisterPartEvent(this, "Took");
        }

        public override void OnQuestComplete()
        {
            //XRL.Core.XRLCore.Core.Game.Player.Body.UnregisterPartEvent(this, "Took");
            XRL.Core.XRLCore.Core.Game.Player.Body.RemovePart(this);
        }

        public override bool FireEvent(Event E)
        {
            if (E.ID == "Took")
            {
                Inventory pInventory = XRL.Core.XRLCore.Core.Game.Player.Body.GetPart("Inventory") as Inventory;

                int OldLength = nTotalLength;
                nTotalLength = 0;

                foreach (GameObject GO in pInventory.GetObjects())
                {
                    if (GO.HasPart("Wire"))
                    {
                        Wire pWire = GO.GetPart("Wire") as Wire;
                        nTotalLength += pWire.Length;
                    }
                }

                if (nTotalLength >= 200)
                {
                    XRL.Core.XRLCore.Core.Game.FinishQuestStep("Finishing the Conduit", "Find 200 feet of copper wire");
                }
                else
                {
                    if( nTotalLength != OldLength )
                    {
                        Messages.MessageQueue.AddPlayerMessage("&cYou now have " + nTotalLength + " feet of copper wire.");
                    }
                }
            }

            return true;
        }
    }
}
