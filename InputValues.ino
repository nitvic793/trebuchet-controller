int beamRotation = 0;
int trebuchetRotation = 0;

void setup() 
{
  Serial.begin(9600);  
  pinMode(A0, INPUT);
  pinMode(A1, INPUT);
}

void loop()
{
  beamRotation = analogRead(A0);
  trebuchetRotation = analogRead(A1);
  Serial.print(map(beamRotation,0,1023,0,270)); 

  Serial.print(",");
  Serial.println(map(trebuchetRotation,0,1023,0,270));  
  
  delay(50);   
}





