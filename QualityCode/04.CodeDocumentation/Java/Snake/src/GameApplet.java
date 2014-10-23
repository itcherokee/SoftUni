import java.applet.Applet;
import java.awt.Dimension;
import java.awt.Graphics;

/**
 * Prepares the Java applet for running the game.
 * Initialize game Engine and UserControl objects.
 */
@SuppressWarnings("serial")
public class GameApplet extends Applet {
	private Engine game;
    UserControl userControl;

    /**
     * Initialize main game objects (Engine & UserControl) as well as
     * Initialize the Java Applet environment.
     */
	public void init(){
		game = new Engine();
		game.setPreferredSize(new Dimension(800, 650));
		game.setVisible(true);
		game.setFocusable(true);
		this.add(game);
		this.setVisible(true);
		this.setSize(new Dimension(800, 650));
        userControl = new UserControl(game);
	}

    /**
     * Initilaize Graphics context used for drawing game objects.
     * @param context Instance of Graphical context - canvas
     *                where to draw game objects.
     */
	public void paint(Graphics context){
		this.setSize(new Dimension(800, 650));
	}
}
