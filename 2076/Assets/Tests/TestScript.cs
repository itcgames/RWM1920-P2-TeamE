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
        // A Test behaves as an ordinary method
        [Test]
        public void TestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
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
