using System;
using UnityEngine;

public class PredictionClient : MonoBehaviour
{
    private PredictionRequester predictionRequester;

    private void Start()
    {
        predictionRequester = new PredictionRequester();
        predictionRequester.Start();
    }

    public void Predict(float[] input, Action<float[]> onOutputReceived)
    {
        predictionRequester.SetOnTextReceivedListener(onOutputReceived);
        predictionRequester.SendInput(input);
    }

    private void OnDestroy()
    {
        predictionRequester.Stop();
    }
}