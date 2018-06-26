#include <Arduino.h>
#include "VarSpeedServo.h"

#ifndef myarm_h
#define myarm_h


#define NumAxes 4

#define RightMotor      0
#define LeftMotor       1
#define RotMotor        2
#define EffectorMotor   3

#define MinArmLength    10
#define MaxArmLength    260 
#define MinArmHeight    -180
#define MaxArmHeight    150
#define MinArmRotation  -90
#define MaxArmRotation   90

#define MinServoPulse   500
#define MaxServoPulse   2800

#define RadiansToDegrees  57.29577951

#define ArmA            148
#define ArmC            161
#define Arm2AC          47656
#define ArmA2           21904
#define ArmC2           25921
#define ArmA2C2         47825



typedef struct 
{
    int Angles[NumAxes];
    int Time;
} StoredPosition;

typedef struct 
{
    char FeedbackAnalogPin;
    char ControlPin;
    int AngleMin;
    int AngleMax;
    int PulseMin;
    int PulseMax;
    int SensorMin;
    int SensorMax;
    int CurrentAngle;
    int LastAngle;

} AxisInfo;


class MyArm
{
  public:

    int MovementTime;  // In ms. Time used to perform a movement on all axes. Smaller is faster.
    bool Engaged;

    MyArm();
    void Init();
    void SetPosition(double length, double height, int rotation, int effectorRotation);
    void SetAngles(int *angles, int time);
    void SetServoSpeed(char axisIndex, unsigned char speed);
    int  ReadAngle(char axisIndex);
    void GripperCatch();
    void GripperRelease();
    void GripperDetach();
    void Attach();
    void Detach();
    void Play(unsigned char buttonPin);
    void Record(unsigned char buttonPin, unsigned char buttonPinC);
    void SetSpeed(int speed);
    void SetTime(int time);
    void PrintRawAngles();
    void ReadAngles(int *outAngles);
    void ReadRawAngles(int *outAngles);

  private:

    void AttachServo(char axisIndex);
    void DetachServo(char axisIndex);
    

    void PrintAngles(int *angles);
    void UpdateCurrentAngles();

    int Speed;
    VarSpeedServo AxesControl[NumAxes];
    AxisInfo Axes[NumAxes];
};

#endif
