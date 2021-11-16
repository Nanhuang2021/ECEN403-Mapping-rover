
    
def moveForward(x):
  """moves forward by x cms. Only accepts positive values,
        try moveBackwards(x) if you wish to move backwards."""
   
  import RPi.GPIO as GPIO
  from time import sleep  
  pwm0Pin = 32
  pwm1Pin = 33
  GPIO.setwarnings(False)
  GPIO.setmode(GPIO.BOARD)
  GPIO.setup(pwm0Pin, GPIO.OUT)
  GPIO.setup(pwm1Pin, GPIO.OUT)
  ch1 = GPIO.PWM(pwm0Pin, 45)
  ch2 = GPIO.PWM(pwm1Pin, 45)

  #initial duty cycle values (no motion)
  ch1Duty = 6.7
  ch2Duty = 6.7
  
  ch1.start(ch1Duty)
  ch2.start(ch2Duty)
  
  #change duty cycle (high/forward)
  ch1Duty = 7.95
  ch1.ChangeDutyCycle(ch1Duty)
  
  #sleep/wait depending on value of x
  sleep(x)
  
  #change duty cycle to neutral (D = 6.7)
  ch1Duty = 6.7 
  ch1.ChangeDutyCycle(ch1Duty)    
    
def moveBackward(x):
  """Moves Backwards by X cm. Only accepts positive values, try
        moveForward(x) if you wish to move forward."""
  import RPi.GPIO as GPIO
  from time import sleep  
  pwm0Pin = 32
  pwm1Pin = 33
  GPIO.setwarnings(False)
  GPIO.setmode(GPIO.BOARD)
  GPIO.setup(pwm0Pin, GPIO.OUT)
  GPIO.setup(pwm1Pin, GPIO.OUT)
  ch1 = GPIO.PWM(pwm0Pin, 45)
  ch2 = GPIO.PWM(pwm1Pin, 45)

  #initial duty cycle values (no motion)
  ch1Duty = 6.7
  ch2Duty = 6.7
  
  ch1.start(ch1Duty)
  ch2.start(ch2Duty)
  
  
  #change duty cycle (low/backwards)
  ch1Duty = 5.45
  ch1.ChangeDutyCycle(ch1Duty)
  
  #wait/sleep depending on value of xrange
  sleep(x)
  
  #change duty cycle back to neutral
  ch1Duty = 6.7
  ch1.ChangeDutyCycle(ch1Duty)
    
def leftTurn(x):
  """Turns left by X-degrees."""
  import RPi.GPIO as GPIO
  from time import sleep  
  pwm0Pin = 32
  pwm1Pin = 33
  GPIO.setwarnings(False)
  GPIO.setmode(GPIO.BOARD)
  GPIO.setup(pwm0Pin, GPIO.OUT)
  GPIO.setup(pwm1Pin, GPIO.OUT)
  ch1 = GPIO.PWM(pwm0Pin, 45)
  ch2 = GPIO.PWM(pwm1Pin, 45)

  #initial duty cycle values (no motion)
  ch1Duty = 6.7
  ch2Duty = 6.7
  
  ch1.start(ch1Duty)
  ch2.start(ch2Duty)
  

  #change duty cycle
  ch2Duty = 5.45    
  ch2.ChangeDutyCycle(ch2Duty)
  
  #wait
  sleep(2)
     
  #change duty cycle back to neutral
  ch2Duty = 6.7
  ch2.ChangeDutyCycle(ch2Duty)

def rightTurn(x):
  """Turns right by X-degrees."""
  import RPi.GPIO as GPIO
  from time import sleep  
  pwm0Pin = 32
  pwm1Pin = 33
  GPIO.setwarnings(False)
  GPIO.setmode(GPIO.BOARD)
  GPIO.setup(pwm0Pin, GPIO.OUT)
  GPIO.setup(pwm1Pin, GPIO.OUT)
  ch1 = GPIO.PWM(pwm0Pin, 45)
  ch2 = GPIO.PWM(pwm1Pin, 45)

  #initial duty cycle values (no motion)
  ch1Duty = 6.7
  ch2Duty = 6.7
  
  ch1.start(ch1Duty)
  ch2.start(ch2Duty)

  #change duty cycle
  ch2Duty = 7.95   
  ch2.ChangeDutyCycle(ch2Duty)
  
  #wait
  sleep(2)
  
  #change duty cycle back to neutral
  ch2Duty = 6.7
  ch2.ChangeDutyCycle(ch2Duty)
      