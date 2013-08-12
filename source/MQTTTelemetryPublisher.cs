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
            client.Publish("ksp/test1/tlm/acceleration", part.vessel.acceleration.magnitude.ToString("F4"), QoS.BestEfforts, false);
            client.Publish("ksp/test1/tlm/g", part.vessel.geeForce.ToString("F4"), QoS.BestEfforts, false);
            client.Publish("ksp/test1/tlm/altitude", part.vessel.altitude.ToString("F1"), QoS.BestEfforts, false);
            client.Publish("ksp/test1/tlm/pressure", part.vessel.staticPressure.ToString("F4"), QoS.BestEfforts, false);
            client.Publish("ksp/test1/tlm/obtv", part.vessel.obt_velocity.magnitude.ToString("F1"), QoS.BestEfforts, false);
            client.Publish("ksp/test1/tlm/srfv", part.vessel.srf_velocity.magnitude.ToString("F1"), QoS.BestEfforts, false);
        }

    }
}
