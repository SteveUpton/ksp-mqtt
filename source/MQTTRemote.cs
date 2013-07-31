using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MqttLib;

public class MQTTRemote : Part {

    protected override void onFlightStart()  //Called when vessel is placed on the launchpad
    {

        System.Random rand = new System.Random();
        String clientID = "ksp" + rand.Next(100000);

        IMqtt _client;
        _client = MqttClientFactory.CreateClient("tcp://m2m.eclipse.org:1883", clientID);
        _client.PublishArrived += new PublishArrivedDelegate(client_PublishArrived);
        print("MQTT Client created");
        _client.Connect(true);
        print("MQTT Client connected");
        _client.Publish("ksp/test1/telemetry/blah", "Connected!", QoS.BestEfforts, false);
        print("MQTT Message published");
        _client.Subscribe("ksp/test1/commands/#", QoS.BestEfforts);   // Subscribe to command topic
        print("MQTT Client subscribed to command topic");

        

        // Create the client
        /*_client = MqttClientFactory.CreateClient("m2m.eclipse.org:1883", "ksptest1");

        // Setup callbacks
        _client.Connected += new ConnectionDelegate(client_Connected);
        _client.PublishArrived += new PublishArrivedDelegate(client_PublishArrived);
        _client.ConnectionLost += new ConnectionDelegate(_client_ConnectionLost);

        _client.Connect(true);  // Connect
        _client.Subscribe("ksp/test1/commands/#", QoS.BestEfforts);   // Subscribe to command topic*/

        //ksp/test1/telemetry/#
        //at the beginning of the flight, register your fly-by-wire control function that will be called repeatedly during flight:
        //FlightInputHandler.OnFlyByWire += new FlightInputHandler.FlightInputCallback(fly);
    }

    bool client_PublishArrived(object sender, PublishArrivedArgs e)
    {
        print("Received MQTT Message");
        print("Topic: " + e.Topic);
        print("Payload: " + e.Payload);

        Staging.ActivateNextStage();

        return true;
    }

    /*void _client_ConnectionLost(object sender, EventArgs e)
    {
        print("MQTT connection lost");
    }*/

}

