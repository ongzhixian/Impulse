package com.emptool.ui;

import org.apache.logging.log4j.Logger;
import org.apache.logging.log4j.LogManager;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class MiniAppDesktop {

    private static final org.apache.logging.log4j.Logger log = LogManager.getLogger(MiniAppDesktop.class);

    JFrame frame = null;

    public MiniAppDesktop()
    {
        this.frame = GetMdiDesktop();
        frame.setVisible(true);
    }

    private JFrame GetMdiDesktop()
    {
        JFrame frame = new JFrame("FrameDemo");
        JDesktopPane desktop = new JDesktopPane();
        DesktopManager manager = new DefaultDesktopManager() {
            private static final long serialVersionUID = 1493970316565972256L;
            public void activateFrame(JInternalFrame f) {
                super.activateFrame(f);
                System.out.println(f);
            }
        };

        desktop.setOpaque(false);
        desktop.setDesktopManager(manager);
 

        JInternalFrame internal = new JInternalFrame("Default Layer #1",
            true, false, true, true);
        JButton button = new JButton("Ok");
        internal.getContentPane().add(button,BorderLayout.CENTER);
        internal.setBounds(25,25,200,75);
        desktop.add(internal, desktop.DEFAULT_LAYER);

        internal = new JInternalFrame("Default Layer #2",
        true,false,true,true);
        button = new JButton("Ok");
        internal.getContentPane().add(button,BorderLayout.CENTER);
        internal.setBounds(50,50,200,75);
        desktop.add(internal,desktop.DEFAULT_LAYER);

        // internal = new JInternalFrame("Always Above",
        // true,false,true,true);
        // button = new JButton("Ok");
        // internal.getContentPane().add(button,BorderLayout.CENTER);
        // internal.setBounds(75,75,200,75);
        // desktop.add(internal,
        // new Integer(desktop.DEFAULT_LAYER.intValue()+1));


        
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setJMenuBar(GetMenuBar());
        
        frame.getContentPane().add(desktop,BorderLayout.CENTER);

        // JLabel label2 = new JLabel("Text-Only Label");
        // frame.getContentPane().add(
        //     label2
        //     , BorderLayout.CENTER);
        
        //frame.setLayout(null);

        //frame.pack();
        frame.setSize(400,400);
        frame.setVisible(true);

        frame.show();

        return frame;
    }

    private JMenuBar GetMenuBar()
    {
        JMenuBar menuBar = new JMenuBar();
        JMenuItem i1, i2, i3, i4, i5;

        i1=new JMenuItem("Item 1");  
        i2=new JMenuItem("Item 2");  
        i3=new JMenuItem("Item 3");  
        i4=new JMenuItem("Item 4");  
        i5=new JMenuItem("Item 5");  

        JMenu submenu = new JMenu("Sub Menu");
        submenu.add(i4); 
        submenu.add(i5);

        JMenu menu = new JMenu("Menu");
        menu.add(i1);
        menu.add(i2);
        menu.addSeparator();
        menu.add(i3);  
        menu.add(submenu); 

        menuBar.add(menu);

        return menuBar;
    }
}