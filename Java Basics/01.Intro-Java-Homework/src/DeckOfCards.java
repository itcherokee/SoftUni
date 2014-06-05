// Task 9:	Write a program to generate a PDF document called Deck-of-Cards.pdf
//			and print in it a standard deck of 52 cards, following one after 
//			another. Each card should be a rectangle holding its face and suit.
// Note: 	Pdf document (DecOfCards.pdf) is created in the root folder 
//			of the application, not in bin folder.

import java.io.*;
import com.pdfjet.*;

public class DeckOfCards {
	public static void main(String[] args) throws Exception {
		int[] suits = { 0xA7, 0xA8, 0xA9, 0xAA };
		String[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J",
				"Q", "K", "A" };
		float cardWidth = 40.0f;
		float cardHeight = 60.0f;
		float fontSize = 15.0f;
		float cardXPosition = 110.0f;
		float cardYPosition = 170.0f;
		int textColor = Color.black;
		float verticalOffset = 0;
		
		FileOutputStream fos = new FileOutputStream("DecOfCards.pdf");

		PDF pdf = new PDF(fos);
		Page page = new Page(pdf, A4.LANDSCAPE);

		// Font used for the values of the cards
		Font fontValue = new Font(pdf, CoreFont.TIMES_BOLD);
		fontValue.setSize(fontSize);
		
		// Font used for the suit of the card
		Font fontSuit = new Font(pdf, CoreFont.SYMBOL);
		fontSuit.setSize(fontSize + 2.0f);

		for (int row = 0; row < suits.length; row++) {
			float horizontalOffset = 5;
			if (row == 0 || row == 3) {
				textColor = Color.black;
			} else {
				textColor = Color.red;
			}

			for (int col = 0; col < values.length; col++) {
				float currentX = cardXPosition + cardWidth / 2 + col
						* cardWidth - fontSize + horizontalOffset + 5;
				float currentY = cardYPosition + cardHeight / 2 + row
						* cardHeight + verticalOffset + 5;
				
				// Draw value of the card
				TextLine character = new TextLine(fontValue, values[col]);
				character.setColor(textColor);
				character.setPosition(currentX, currentY);
				character.drawOn(page);

				// Draw type of suit of current cards
				character.setFont(fontSuit);
				character.setText(String.valueOf((char) suits[row]));
				float suitOffset = fontSize - 7.0f;
				if (col == 8) {
					suitOffset += 6;
				} else if (col > 9) {
					suitOffset += 3;
				}

				character.setPosition(currentX + suitOffset, currentY);
				character.drawOn(page);

				// Draw borders of the cards
				Box box = new Box(cardXPosition + col * cardWidth
						+ horizontalOffset, cardYPosition + row * cardHeight
						+ verticalOffset, cardWidth, cardHeight);
				box.setColor(50);
				box.drawOn(page);
				horizontalOffset += 5;
			}

			verticalOffset += 5;
		}

		pdf.flush();
		fos.close();
	}
}