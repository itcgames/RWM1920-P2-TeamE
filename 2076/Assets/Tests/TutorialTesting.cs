using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TutorialTesting
    {
        GameObject Help = Resources.Load("Help") as GameObject;

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TutorialTestUpdate()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            //Help.GetComponent<ManageTutorialText>().st;
            Help.GetComponent<ManageTutorialText>().Start();
            Help.GetComponent<ManageTutorialText>().updateText();
            string currentName = Help.GetComponent<ManageTutorialText>().getText();
            Debug.Log(currentName);
            yield return new WaitForSeconds(0.1f);

            Assert.AreEqual(currentName, "PlayButtonInfo");
        }

        [UnityTest]
        public IEnumerator TutorialTestCloseInstructions()
        {
            Help.GetComponent<ManageTutorialText>().Start();
            for (int i = 0; i < 9; i++)
            {
                Help.GetComponent<ManageTutorialText>().updateText();
            }
            yield return new WaitForSeconds(0.1f);

            Assert.AreEqual(Help.active, false);
        }
    }
}
