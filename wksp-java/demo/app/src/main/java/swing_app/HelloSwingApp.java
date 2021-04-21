package swing_app;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import static java.lang.System.out;
import javax.swing.*;

public class HelloSwingApp {

    private static final Logger logger = LogManager.getLogger(HelloSwingApp.class);

    public HelloSwingApp()
    {
        out.println("HelloSwingApp");

    }

    public void Run()
    {
        JFrame f = new JFrame("Hello Swing App");//creating instance of JFrame  
        f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

                
        JButton b=new JButton("click");//creating instance of JButton  
        b.setBounds(130,100,100, 40);//x axis, y axis, width, height  
                
        f.add(b);//adding button in JFrame  

         //Add the ubiquitous "Hello World" label.
         JLabel label = new JLabel("Hello World");
         //frame.getContentPane().add(label);
         f.add(label);
        
        f.setSize(400,500);//400 width and 500 height  
        f.setLayout(null);//using no layout managers  
        f.setVisible(true);//making the frame visible  
          
    }

    
    static int getNumber() {
        return 5;
    }

}