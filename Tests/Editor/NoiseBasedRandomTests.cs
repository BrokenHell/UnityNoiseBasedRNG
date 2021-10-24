using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zodiark.Utilities;

public class RandomTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void RandomValue()
    {
        var random = new NoiseBasedRandom(200);
        var random2 = new NoiseBasedRandom(200);

        Assert.True(random.Value == random2.Value);
        Assert.True(random.Range(0f, 1f) != random2.Range(0f, 2f));
        Assert.True(random.Range(0f, 1f) != random.Range(0f, 1f));

        random.CurrentPosition = random2.CurrentPosition;

        Assert.True(random.Range(0f, 1f) == random2.Range(0f, 1f));
    }

    [Test]
    public void RandomRange()
    {
        var random = new NoiseBasedRandom(200);
        var random2 = new NoiseBasedRandom(200);

        Assert.True(random.Range(20, 40) == random2.Range(20, 40)); // position = 2

        var random3 = new NoiseBasedRandom(300);
        var _ = random3.Value; // position = 1

        Assert.True(random.Value != random3.Value); // Compare position 2
    }
}
