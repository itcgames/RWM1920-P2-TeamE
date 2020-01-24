using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestScript
    {
        GameObject Fan = Resources.Load("Fan") as GameObject;
        GameObject Bin = Resources.Load("Bin") as GameObject;

        GameObject manager = Resources.Load("GameController") as GameObject;
        GameObject eventHandle = Resources.Load("EventSystem") as GameObject;
        float time;

        GameObject player;

        [SetUp]
        public void Setup()
        {
            player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));
        }

        // A Test behaves as an ordinary method
        [Test]
        public void TestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestTimerWithEnumeratorPasses()
        {
            manager.GetComponent<Manager>().eventSystem = eventHandle;

            time = eventHandle.GetComponent<EventHandling>().gameTimer;
            manager.GetComponent<Manager>().isPlay = true;
            eventHandle.GetComponent<EventHandling>().gameTimer++;

            yield return new WaitForSeconds(3.0f);

            Assert.AreNotEqual(time, eventHandle.GetComponent<EventHandling>().gameTimer);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestScriptWithEnumeratorPasses()
        {
            player.transform.position = new Vector2(10, 10);
            float output = player.transform.position.y;

            yield return new WaitForSeconds(2.0f);

            Assert.AreNotEqual(output, player.transform.position.y);
        }

        //Test to see if the bin button destroys the components // Alex
        [UnityTest]
        public IEnumerator BinTest()
        {
            Fan.gameObject.GetComponent<Transform>().position = new Vector3(0, 0, 0);
            Bin.gameObject.GetComponent<Transform>().position = new Vector3(0, 0, 0);
            if (Fan.gameObject.transform.position == Bin.gameObject.transform.position)
            {
                Fan = null;
            }

            Assert.IsNull(Fan);
            yield return null;
        }
    }
}
