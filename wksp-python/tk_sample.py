################################################################################
# Modules and functions import statements
################################################################################

import logging
from helpers.app_logging import setup_logging, print_test_log_messages
# from modules import *
# from api import *
# from pages import *
# from os import getenv

################################################################################
# Main function
################################################################################

def clicked():
    hello_label.configure(text="Button was clicked !!")
    messagebox.showinfo('Message title','Message content')
    #messagebox.showwarning('Message title', 'Message content')  #shows warning message
    #messagebox.showerror('Message title', 'Message content')    #shows error message

if __name__ == '__main__':
    setup_logging()
    #print_test_log_messages()
    logging.info("[PROGRAM START]")

    #import tkinter as tk
    from tkinter import Tk, Label, Button, Entry, BooleanVar, messagebox
    from tkinter.ttk import Combobox, Checkbutton
    window = Tk()
    window.title("ako apps")
    window.geometry('350x200')

    username_label = Label(window, text="Username")
    username_label.grid(column=1, row=1)
    password_label = Label(window, text="Password")
    password_label.grid(column=1, row=2)

    username_entry = Entry(window, width=20)
    username_entry.grid(column=2, row=1)
    password_entry = Entry(window, width=20)
    password_entry.grid(column=2, row=2)

    log_in_button = Button(window, text="Log in")
    log_in_button.grid(column=3, row=1)

    combo = Combobox(window)
    combo['values']= (1, 2, 3, 4, 5, "Text")
    combo.current(1) #set the selected item
    combo.grid(column=2, row=3)
    
    chk_state = BooleanVar()
    chk_state.set(True) #set check state
    chk = Checkbutton(window, text='Choose', var=chk_state)
    chk.grid(column=3, row=3)

    username_entry.focus()

    # hello_label = Label(window, text="Hello", font=("Arial Bold", 50))
    # hello_label.grid(column=0, row=0)

    # btn2 = Button(window, text="Button Two", bg="orange", fg="red", command=clicked)
    # btn2.grid(column=2, row=0)

    
    window.mainloop()
    logging.info("[PROGRAM END]")
    
