using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using Zodiark.Utilities;

namespace Zodiark.Demos
{
    /// <summary>
    /// Noise-based random demo
    /// </summary>
    public class NoiseBasedRandomDemo : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputSeed;
        [SerializeField] private TMP_InputField inputPosition;
        [SerializeField] private TMP_InputField minRange;
        [SerializeField] private TMP_InputField maxRange;

        [SerializeField] private TMP_Text labelResult;

        //private IEnumerator Start()
        //{
        //    uint call = 0;
        //    int positionX = 0;
        //    int positionY = 0;
        //    int positionZ = 0;
        //    int positionT = 0;
        //    Utilities.Random myRand = new Utilities.Random();
        //    Stopwatch stopwatch = new Stopwatch();
        //    uint total = 100000000;
        //    float value1 = 0f;
        //    var seed = (uint)(System.DateTime.Now.Ticks & 0x0000FFFF);

        //    stopwatch.Start();
        //    while (call < total)
        //    {
        //        value1 = myRand.Value;
        //        call += 1;
        //    }
        //    stopwatch.Stop();

        //    UnityEngine.Debug.LogError($"Noise-based RNG {total} calls take {stopwatch.Elapsed} ");

        //    call = 0;
        //    uint value4 = 0;


        //    stopwatch.Reset();
        //    stopwatch.Start();
        //    while (call < total)
        //    {
        //        value4 = NoiseBasedRNG.Get2dNoiseUnit(positionX++, positionY++, seed);
        //        call += 1;
        //    }

        //    stopwatch.Stop();

        //    UnityEngine.Debug.LogError($"True Noise-based RNG {total} calls take {stopwatch.Elapsed} ");


        //    float value2 = 0f;
        //    call = 0;


        //    stopwatch.Reset();
        //    stopwatch.Start();
        //    while (call < total)
        //    {
        //        value2 = UnityEngine.Random.value;
        //        call += 1;
        //    }

        //    stopwatch.Stop();

        //    UnityEngine.Debug.LogError($"Unity RNG {total} calls take {stopwatch.Elapsed} ");

        //    System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
        //    int value3 = 0;
        //    call = 0;


        //    stopwatch.Reset();
        //    stopwatch.Start();
        //    while (call < total)
        //    {
        //        value3 = rand.Next();
        //        call += 1;
        //    }

        //    stopwatch.Stop();

        //    UnityEngine.Debug.LogError($"C# RNG {total} calls take = {stopwatch.Elapsed} ");
        //    yield break;
        //}

        public void RandomValue()
        {
            Utilities.NoiseBasedRandom r = new Utilities.NoiseBasedRandom();
            labelResult.text = r.Value.ToString();
        }

        public void RandomWithSeedAndPos()
        {
            Utilities.NoiseBasedRandom r = new Utilities.NoiseBasedRandom(uint.Parse(inputSeed.text),
                                                        int.Parse(inputPosition.text));

            labelResult.text = r.Value.ToString();
        }

        public void RandomWithRangeInt()
        {
            Utilities.NoiseBasedRandom r = new Utilities.NoiseBasedRandom();

            labelResult.text = r.Range(int.Parse(minRange.text), int.Parse(maxRange.text)).ToString();
        }

        public void RandomWithRangeFloat()
        {
            Utilities.NoiseBasedRandom r = new Utilities.NoiseBasedRandom();

            labelResult.text = r.Range(float.Parse(minRange.text), float.Parse(maxRange.text)).ToString();
        }
    }
}
