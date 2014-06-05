// Task 9:	Create a class Product to hold products, which have name (string) and price (decimal number). 
//			Read from a text file named "Input_stock.txt" a list of products. Each product will be in format 
//			name + space + price. You should hold the products in objects of class Product. 
//			Sort the products by price and write them in format price + space + name in a file named 
//			"Output_stock.txt". Ensure you close correctly all used resources.

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;

public class _09_ListOfProducts {

	public static void main(String[] args) {
		ArrayList<Product> listOfProducts = loadDataFromFile("src/Input_stock.txt");
		Collections.sort(listOfProducts, new Comparator<Product>() {
			public int compare(Product one, Product other) {
				double difference = one.getPrice() - other.getPrice();
				if (Math.abs(difference) <= 0.000001) {
					return 0;
				} else {
					return (int) Math.floor(difference);
				}
			}

		});

		saveDataToFile("src/Output_stock.txt", listOfProducts);
	}

	private static ArrayList<Product> loadDataFromFile(String file) {
		String fileName = file;
		ArrayList<Product> content = new ArrayList<Product>();
		try (BufferedReader fileReader = new BufferedReader(new FileReader(fileName));) {
			while (true) {
				String line = fileReader.readLine();
				if (line == null || line.length() < 1) {
					break;
				}

				String[] lineContent = line.split(" ");
				content.add(new Product(lineContent[0], Double.parseDouble(lineContent[1])));
			}

		} catch (IOException ex) {
			System.out.println("Error");
		}

		return content;
	}

	private static void saveDataToFile(String file, ArrayList<Product> content) {
		String fileName = file;

		try (BufferedWriter fileWriter = new BufferedWriter(new FileWriter(fileName));) {
			for (Product product : content) {
				fileWriter.write(product.getPrice() + " " + product.getName() + System.getProperty("line.separator"));
			}

		} catch (IOException ex) {
			System.out.println("Error");
		}
	}
}
