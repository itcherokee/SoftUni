package com.softuni.oop.geometry;

public class Point3D extends Point2D {
    private double z;

    public Point3D(double coordinateX, double coordinateY, double coordinateZ) {
        super(coordinateX, coordinateY);
        this.setZ(coordinateZ);
    }

    public double getZ() {
        return this.z;
    }

    public void setZ(double coordinateZ) {
        this.z = coordinateZ;
    }

    @Override
    public String toString() {
        return super.toString() + String.format(",%s", this.getZ());
    }
}
