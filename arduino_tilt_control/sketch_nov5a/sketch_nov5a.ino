int tiltX = 9;    // Pin connected to X-axis tilt sensor
int tiltNegX = 11; // Pin connected to -X-axis tilt sensor
int tiltY = 12;    // Pin connected to Y-axis tilt sensor
int tiltNegY = 10; // Pin connected to -Y-axis tilt sensor

void setup() {
  // Set up each tilt sensor pin as an input
  pinMode(tiltX, INPUT);
  pinMode(tiltNegX, INPUT);
  pinMode(tiltY, INPUT);
  pinMode(tiltNegY, INPUT);

  // Start serial communication to send data to Unity
  Serial.begin(115200);
}

void loop() {
  // Determine X value based on tilt sensor readings
  int X = 1; // Default to 0 (neutral)
  if (digitalRead(tiltX) == 1) {
    X = 2;  // Positive tilt
  } else if (digitalRead(tiltNegX) == 1) {
    X = 0;  // Negative tilt
  }

  // Determine Y value based on tilt sensor readings
  int Y = 1; // Default to 0 (neutral) 
  if (digitalRead(tiltY) == 1) {
    Y = 2;  // Positive tilt
  } else if (digitalRead(tiltNegY) == 1) {
    Y = 0;  // Negative tilt
  }

  // Send the X and Y values to Unity as a comma-separated string
  Serial.print(X);
  Serial.print(",");
  Serial.println(Y);

  // Small delay to control data transmission speed
  delay(50); // Adjust as needed
}
