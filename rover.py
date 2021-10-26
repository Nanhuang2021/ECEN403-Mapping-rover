import RPi.GPIO as GPIO
from time import sleep



    
#setup GPIO
pwm0Pin = 32
pwm1Pin = 33
GPIO.setwarnings(False)
GPIO.setmode(GPIO.BOARD)
GPIO.setup(pwm0Pin, GPIO.OUT)
GPIO.setup(pwm1Pin, GPIO.OUT)
ch1 = GPIO.PWM(pwm0Pin, 45)
ch2 = GPIO.PWM(pwm1Pin, 45)



#initial duty cycle values (no motion)
global ch1Duty
global ch2Duty

ch1Duty = 6.7
ch2Duty = 6.7

ch1.start(ch1Duty)
ch2.start(ch2Duty)


try:
    # Python2
    import Tkinter as tk
except ImportError:
    # Python3
    import tkinter as tk


def key(event):
    """shows key or tk code for the key"""
    global ch1Duty
    global ch2Duty
####escape key
    if event.keysym == 'Escape':
        root.destroy()

####numbers: 0 to stop motion################
    if event.char == event.keysym:
        # normal number and letter characters
        print( 'Normal Key %r' % event.char )
        #if 0 both channels to 6.7% duty cycle (stop)
        if event.char == '0':
            ch1.ChangeDutyCycle(6.7)
            ch1.ChangeDutyCycle(6.7)

    #elif len(event.char) == 1:
        # charcters like []/.,><#$ also Return and ctrl/key
        #print( 'Punctuation Key %r (%r)' % (event.keysym, event.char) )
    else:
        # f1 to f12, shift keys, caps lock, Home, End, Delete ...
        print( 'Special Key %r' % event.keysym )
        
        
        if event.keysym == 'KP_0':
            ch1Duty = 6.7
            ch1.ChangeDutyCycle(ch1Duty)

            
            ch2Duty = 6.7
            ch2.ChangeDutyCycle(ch2Duty)

        
        
        #if up increase CH1 Duty Cycle
        if event.keysym == "Up":
            ch1Duty = ch1Duty + 0.1
            ch1.ChangeDutyCycle(ch1Duty)
            
        #elif down decrease CH1 Duty Cycle
        elif event.keysym == "Down":
            ch1Duty = ch1Duty - 0.1
            ch1.ChangeDutyCycle(ch1Duty)
        

        #elif right increase ch2 Duty Cycle
        elif event.keysym == "Right":
            ch2Duty = ch2Duty + 0.1
            ch2.ChangeDutyCycle(ch2Duty)

        #elif left decrease ch2 Duty Cycle
        elif event.keysym == "Left":
            ch2Duty = ch2Duty - 0.1
            ch2.ChangeDutyCycle(ch2Duty)

root = tk.Tk()
print( "Press a key (Escape key to exit):" )
root.bind_all('<Key>', key)
# don't show the tk window
#sroot.withdraw()
root.mainloop()
