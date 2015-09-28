using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyArmClient
{
    public class Path
    {
        private List<PathStep> mSteps = new List<PathStep>();

        
        public String Name { get; set; }

        public List<PathStep> Steps
        {
            get { return mSteps; }
        }

        [XmlIgnore]
        public bool IsPlaying { get; private set; }


        // __ Playback ________________________________________________________


        /// <summary>
        /// Plays this path on the given client using a background thread.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="beforeStepCallback">Called before sending a path step to the robot.</param>
        /// <param name="finishedCallback">Called when the playback has finished.</param>
        public void Play(Client client, Action<PathStep> beforeStepCallback = null, Action finishedCallback = null)
        {
            ThreadPool.QueueUserWorkItem( (o) =>
            {
                IsPlaying = true;

                try
                {
                    foreach (var step in mSteps)
                    {
                        if (beforeStepCallback != null) beforeStepCallback(step);

                        PlaySingleStep(client, step);
                    }
                }
                catch
                {
                    // May want to include a callback for errors
                }
                finally
                {
                    IsPlaying = false;

                    if (finishedCallback != null) finishedCallback();
                }
            });
        }

        public void PlaySingleStep(Client client, PathStep step)
        {
            var angles = IkSolver.GetAnglesForXYZ(step.Position, 148, 161);
            client.SetAngles(angles, step.Time);
            Thread.Sleep(step.Time);
        }


        // __ Serialization ___________________________________________________


        public static Path Load(string fileName)
        {
            using (var r = new StreamReader(fileName))
            {
                var s = new XmlSerializer(typeof(Path));
                return s.Deserialize(r) as Path;
            }
        }

        public void Save(string fileName)
        {
            using (var w = new StreamWriter(fileName))
            {
                var s = new XmlSerializer(typeof(Path));
                s.Serialize(w, this);
            }
        }
    }
}
