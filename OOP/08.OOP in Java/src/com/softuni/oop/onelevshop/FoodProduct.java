package com.softuni.oop.onelevshop;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

public class FoodProduct extends Product implements Expirable {
    private Date expirationDate;

    protected FoodProduct(
            String name, double price, int quantity, AgeRestriction ageRestriction, String expirationDate) {
        super(name, price, quantity, ageRestriction);
        this.setExpirationDate(expirationDate);
    }

    public Date getExpirationDate() {
        return this.expirationDate;
    }

    private void setExpirationDate(String date) {
        SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
        try {
            this.expirationDate = dateFormat.parse(date);
        } catch (ParseException ex) {
            System.out.println("Invalid date specified.");
        }
    }

    @Override
    public double getPrice() {
        Calendar calendar = Calendar.getInstance();
        calendar.setTime(new Date());
        calendar.add(Calendar.DATE, 15);

        if (calendar.getTime().after(this.expirationDate)) {
            return this.getPriceOfProduct() * 0.70;
        }

        return this.getPriceOfProduct();
    }

    @Override
    public String toString() {
        return super.toString() + ", expiration date = " + this.getExpirationDate();
    }
}
