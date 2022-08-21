using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace Code
{
    public static class StopwatchExtensions
    {
        public delegate void TestFunction();
        public static long RunTest(this Stopwatch stopwatch, TestFunction testFunction)
        {
            stopwatch.Reset();
            stopwatch.Start();
 
            testFunction();
 
            return stopwatch.ElapsedMilliseconds;
        }
    }
 
    public class CoroutineTestScript : MonoBehaviour
    {
        private Rect drawRect;
        private bool showModeScreen;
        private long startTime;
 
        private const float UpdateInterval = 1;
        private float totalTime;
        private int numFrames;
        private float timeleft;
        private float fps;
 
        void Start()
        {
            drawRect = new Rect(0, 0, Screen.width, Screen.height);
            showModeScreen = true;
        }
 
        void OnGUI()
        {
            if (showModeScreen)
            {
                GUI.Label(new Rect(0, 0, 200, 25), "How many coroutines?");
                if (GUI.Button(new Rect(0, 25, 100, 25), "1,000"))
                {
                    StartTest(1000);
                }
                else if (GUI.Button(new Rect(0, 50, 100, 25), "10,000"))
                {
                    StartTest(10000);
                }
                else if (GUI.Button(new Rect(0, 75, 100, 25), "100,000"))
                {
                    StartTest(100000);
                }
            }
            else
            {
                timeleft -= Time.deltaTime;
                totalTime += Time.timeScale / Time.deltaTime;
                numFrames++;
 
                if (timeleft <= 0)
                {
                    fps = totalTime / numFrames;
                    timeleft = UpdateInterval;
                    totalTime = 0;
                    numFrames = 0;
                }
 
                GUI.Label(drawRect, "Start Time: " + startTime + ", FPS: " + fps);
            }
        }
 
        private void StartTest(int numCoroutines)
        {
            showModeScreen = false;
 
            var stopwatch = new Stopwatch();
            startTime = stopwatch.RunTest(
                () => {
                    for (var i = 0; i < numCoroutines; ++i)
                    {
                        StartCoroutine(CoroutineFunction());
                    }
                }
            );
        }
 
        private IEnumerator CoroutineFunction()
        {
            do
            {
                yield return null;
            }
            while (true);
        }
    }
}