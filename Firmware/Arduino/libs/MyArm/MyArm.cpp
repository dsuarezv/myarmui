#include "MyArm.h"

MyArm::MyArm()
{
	MovementTime = 500;
    Speed = 0;
    Engaged = false;
}

void MyArm::Init()
{
    Axes[LeftMotor].FeedbackAnalogPin = 3;
    Axes[LeftMotor].ControlPin = 10;
    Axes[LeftMotor].AngleMin = 73;
    Axes[LeftMotor].AngleMax = 146;
    Axes[LeftMotor].SensorMin = 241;
    Axes[LeftMotor].SensorMax = 380;
    Axes[LeftMotor].PulseMin = 1300;
    Axes[LeftMotor].PulseMax = 2050;

    Axes[RightMotor].FeedbackAnalogPin = 1;
    Axes[RightMotor].ControlPin = 11;
    Axes[RightMotor].AngleMin = 10;
    Axes[RightMotor].AngleMax = 135;
    Axes[RightMotor].SensorMin = 115;
    Axes[RightMotor].SensorMax = 437;
    Axes[RightMotor].PulseMin = 600;
    Axes[RightMotor].PulseMax = 2300;

    Axes[RotMotor].FeedbackAnalogPin = 2;
    Axes[RotMotor].ControlPin = 3;
    Axes[RotMotor].AngleMin = 20;
    Axes[RotMotor].AngleMax = 160;
    Axes[RotMotor].SensorMin = 141;
    Axes[RotMotor].SensorMax = 426;
    Axes[RotMotor].PulseMin = 800;
    Axes[RotMotor].PulseMax = 2300;

    Axes[EffectorMotor].FeedbackAnalogPin = 3;
    Axes[EffectorMotor].ControlPin = 5;
    Axes[EffectorMotor].AngleMin = 73;
    Axes[EffectorMotor].AngleMax = 146;
    Axes[EffectorMotor].SensorMin = 999;
    Axes[EffectorMotor].SensorMax = 999;
    Axes[EffectorMotor].PulseMin = 1300;
    Axes[EffectorMotor].PulseMax = 2050;

    UpdateCurrentAngles();
}

void MyArm::Attach()
{
    for (int i = 0; i < NumAxes; ++i) AttachServo(i);

    Engaged = true;
}

void MyArm::Detach()
{
    for (int i = 0; i < NumAxes; ++i) DetachServo(i);

    Engaged = false;
}

void MyArm::SetAngles(int *angles, int time)
{
    for (int i = 0; i < NumAxes; ++i) 
    {
        AxisInfo *axis = &Axes[i];
        int targetAngle = angles[i];
        int angle = targetAngle - axis->LastAngle;
        //targetAngle = constrain(targetAngle, axis->AngleMin, axis->AngleMax);
        //targetAngle = map(targetAngle, axis->AngleMin, axis->AngleMax, axis->PulseMin, axis->PulseMax);
        //int speed = (int)((float)angle * 1000.0f / (float)time);
        //if (speed < 0) speed = -speed;

        AxesControl[i].write(targetAngle, Speed, false);
        axis->LastAngle = targetAngle;
    }
    
    //PrintAngles(angles);
    //Serial.print("rawSensors: "); printRawAngles(); Serial.println();
}

void MyArm::SetPosition(double length, double height, int rotation, int effectorRotation)
{
    rotation = rotation;

    length = constrain(length, MinArmLength, MaxArmLength);
    height = constrain(height, MinArmHeight, MaxArmHeight);
    rotation = constrain(rotation, MinArmRotation, MaxArmRotation);

    double x2y2 = length * length + height * height;
    double delta = atan(height / length) * RadiansToDegrees;
    double gamma = acos( (ArmA2 + x2y2 - ArmC2) / (2 * ArmA * sqrt(x2y2)) ) * RadiansToDegrees;
    double epsilon = acos( (ArmA2C2 - x2y2) / (Arm2AC) ) * RadiansToDegrees;

/*
    Serial.print("Angles: d");
    Serial.print(delta);
    Serial.print(" g");
    Serial.print(gamma);
    Serial.print(" e");
    Serial.print(epsilon);
*/
    double leftAngle = 180 - delta - gamma - epsilon;
    double rightAngle = delta + gamma;
/*
    Serial.print(" LEFT");
    Serial.print(leftAngle);
    Serial.print(" RIGHT");
    Serial.print(rightAngle);
    */
}

void MyArm::SetServoSpeed(char axisIndex, unsigned char _servoSpeed) // 0=full speed, 1-255 slower to faster
{
	
}

/*void MyArm::PrintRawAngles()
{
    for (int i = 0; i < NumAxes; ++i)
    {
        AxisInfo axis = &Axes[i];
        //out_angles[i] = (pin >= 0) ? analogRead(pin) : -1;

        if (axis->FeedbackAnalogPin < 0) continue;

        Serial.print((char)('a' + i));
        Serial.print(analogRead(pin));
        Serial.print(' ');
    }
}
*/

void MyArm::UpdateCurrentAngles()
{
    for (int i = 0; i < NumAxes; ++i) ReadAngle(i);
}

void MyArm::ReadAngles(int *outAngles)
{
    for (int i = 0; i < NumAxes; ++i) outAngles[i] = ReadAngle(i);
}

void MyArm::ReadRawAngles(int *outAngles)
{
    for (int i = 0; i < NumAxes; ++i) 
    {
        AxisInfo *axis = &Axes[i];

        int feedbackPin = axis->FeedbackAnalogPin;
        if (feedbackPin >= 0)
        {
            outAngles[i] = analogRead(feedbackPin);
        }
        else
        {
            outAngles[i] = 0;
        }
    }
}

int MyArm::ReadAngle(char axisIndex)
{
    AxisInfo *axis = &Axes[axisIndex];

    int feedbackPin = axis->FeedbackAnalogPin;
    if (feedbackPin >= 0)
    {
        int rawValue = analogRead(feedbackPin);
        int mapped = map(rawValue, axis->SensorMin, axis->SensorMax, axis->AngleMin, axis->AngleMax);
        axis->CurrentAngle = mapped;
        /*
        Serial.print((char)('a' + axisIndex));
        Serial.print(" raw ");
        Serial.print(rawValue);
        Serial.print(" mapped ");
        Serial.print(mapped);
        Serial.print(" sensormin ");
        Serial.print(axis->SensorMin);
        Serial.print(" sensormax ");
        Serial.print(axis->SensorMax);
        Serial.print(" anglemin ");
        Serial.print(axis->AngleMin);
        Serial.print(" anglemax ");
        Serial.print(axis->AngleMax);
        Serial.println();
        */
    }

	return axis->CurrentAngle;
}

void MyArm::GripperCatch()
{
}

void MyArm::GripperRelease()
{
}

void MyArm::GripperDetach()
{
}

void MyArm::AttachServo(char axisIndex)
{
    AxesControl[axisIndex].attach(Axes[axisIndex].ControlPin, MinServoPulse, MaxServoPulse);
}

void MyArm::DetachServo(char axisIndex)
{
    this->AxesControl[axisIndex].detach();
}

void MyArm::PrintAngles(int *angles)
{
    for (int i = 0; i < NumAxes; ++i) 
    {
        Serial.print((char)('a' + i));
        Serial.print(angles[i]);
        Serial.print(' ');
    }
    
    Serial.println();
}


void MyArm::SetTime(int time)
{
    if (time > 100 && time < 10000)
    {
        MovementTime = time;
        //Serial.print("Movement time set to ");
        //Serial.println(time);
    }
}


void MyArm::SetSpeed(int speed)
{
    if (speed > 5 && speed < 254)
    {
        Speed = speed;
    }
}
