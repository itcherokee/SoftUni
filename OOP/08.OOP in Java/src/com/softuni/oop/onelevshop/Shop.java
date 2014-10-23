package com.softuni.oop.onelevshop;

import java.util.ArrayList;
import java.util.List;

public class Shop {
    public static void main(String[] args) {
        List<Product> products = new ArrayList<Product>();
        FoodProduct cigars = new FoodProduct("420 Blaze it fgt", 6.90, 1400, AgeRestriction.ADULT, "25.10.2015");
        try {
            Customer pecata = new Customer("Pecata", 17, 30.00);
            PurchaseManager.processPurchase(cigars, pecata);
        } catch (NullPointerException | IllegalArgumentException ex) {
            System.out.println(ex.getMessage());
        }

        try {

            Customer gopeto = new Customer("Gopeto", 18, 0.44);
            PurchaseManager.processPurchase(cigars, gopeto);
        } catch (NullPointerException | IllegalArgumentException ex) {
            System.out.println(ex.getMessage());
        }

        products.add(cigars);
        products.add(new FoodProduct("Milk", 2.00, 100, AgeRestriction.NONE, "30.10.2014"));
        products.add(new FoodProduct("Tomato", 0.10, 2000, AgeRestriction.NONE, "20.10.2014"));
        products.add(new Computer("DELL - laptop", 1520.10, 5, AgeRestriction.NONE));
        products.add(new Computer("Toshiba - laptop", 1000, 10, AgeRestriction.NONE));
        products.add(new Appliance("Vibrator", 110.10, 49, AgeRestriction.ADULT));

        Product soonestExpirableProduct = products.stream()
                .filter(product -> product instanceof Expirable)
                .map(product -> (FoodProduct) product)
                .sorted((productOne, productTwo) ->
                        productOne.getExpirationDate().before(productTwo.getExpirationDate())
                                ? -1
                                : productOne.getExpirationDate().after(productTwo.getExpirationDate()) ? 1 : 0)
                .findFirst()
                .get();

        System.out.println(String.format("\nSoonest expirable product: %s\n", soonestExpirableProduct));

        System.out.println("Products restricted only to adults:");
        products.stream()
                .filter(product -> product.getAgeRestriction() == AgeRestriction.ADULT)
                .sorted((productOne, productTwo) -> Double.compare(productOne.getPrice(), productTwo.getPrice()))
                .forEach(System.out::println);
    }
}
