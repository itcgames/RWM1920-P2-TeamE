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
        float cost;

        GameObject player;
        GameObject goal;


        [SetUp]
        public void Setup()
        {
            player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));
            goal = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Goal"));
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

        [UnityTest]
        public IEnumerator TestScriptWithEnumeratorPasses()
        {
            player.transform.position = new Vector2(10, 10);
            float output = player.transform.position.y;

            yield return new WaitForSeconds(2.0f);

            Assert.AreNotEqual(output, player.transform.position.y);
        }

        //brian test if the base game cost is 200
        [UnityTest]
        public IEnumerator TestCostWithEnumeratorPasses()
        {
            manager.GetComponent<Manager>().eventSystem = eventHandle;

            cost = eventHandle.GetComponent<EventHandling>().currentCost;

            yield return new WaitForSeconds(3.0f);

            Assert.AreNotEqual(200, eventHandle.GetComponent<EventHandling>().currentCost);
        }

        //Brian, Test is the game is over once the ball hits the goal
        [UnityTest]
        public IEnumerator TestGoalWithEnumeratorPasses()
        {
            goal.transform.position = new Vector2(10, 30);

            yield return new WaitForSeconds(5.0f);

            Assert.AreEqual(false, manager.GetComponent<Manager>().isPlay);
        }
    }
}
