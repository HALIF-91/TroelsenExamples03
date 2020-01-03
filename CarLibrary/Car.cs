using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarLibrary
{
    public enum MusicMedia
    {
        musicCd, musicTape, musicRadio, musicMp3
    }
    public enum EngineState
    {
        engineAlive, engineDead
    }
    public abstract class Car
    {
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }

        protected EngineState egnState = EngineState.engineAlive;
        public Car() 
        {
            MessageBox.Show("CarLibrary Version 2.0!");
        }
        public Car(string name, int maxSp, int currSp)
        {
            MessageBox.Show("CarLibrary Version 2.0!");
            PetName = name;
            MaxSpeed = maxSp;
            CurrentSpeed = currSp;
        }
        public EngineState EngineState
        {
            get { return egnState; }
        }
        public abstract void TurboBoost();
        public void TurnOnRadio(bool musicOn, MusicMedia mm)
        {
            if (musicOn)
                MessageBox.Show(string.Format("Jamming {0}", mm));
            else
                MessageBox.Show("Quiet time...");
        }
    }
}
