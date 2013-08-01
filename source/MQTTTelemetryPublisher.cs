using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MqttLib;

namespace MQTTKSP
{
    class MQTTTelemetryPublisher : MQTTPartModule
    {

        public override void OnUpdate()
        {
            base.OnUpdate();
            client.Publish("ksp/test1/tlm/acceleration", part.vessel.acceleration.magnitude.ToString(), QoS.BestEfforts, false);
            client.Publish("ksp/test1/tlm/g", part.vessel.geeForce.ToString(), QoS.BestEfforts, false);
            client.Publish("ksp/test1/tlm/altitude", part.vessel.altitude.ToString(), QoS.BestEfforts, false);
        }

    }
}
