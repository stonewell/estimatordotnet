package com.angelstone.stock.data;

import java.io.IOException;
import java.io.InputStream;

import com.angelstone.stock.io.StockDataReader;

public class DayData {
    public int date = 0;
    public int open = 0;
    public int high = 0;
    public int low = 0;
    public int close = 0;
    public float amount = 0.0f;
    public int vol = 0;
    public int reservation = 0;

    public DayData() {
    	
    }
    
    public void read(InputStream is) throws IOException {
    	date = StockDataReader.readInt(is);
    	open = StockDataReader.readInt(is);
    	high = StockDataReader.readInt(is);
    	low = StockDataReader.readInt(is);
    	close = StockDataReader.readInt(is);
    	amount = StockDataReader.readFloat(is);
    	vol = StockDataReader.readInt(is);
    	reservation = StockDataReader.readInt(is);
    }
    
    public String toString() {
    	StringBuffer buf = new StringBuffer(100);
    	
		buf.append("lday ");
    	buf.append("Date:").append(date).append(" ");
    	buf.append("Open:").append(open).append(" ");
    	buf.append("High:").append(high).append(" ");
    	buf.append("Low:").append(low).append(" ");
    	buf.append("Close:").append(close).append(" ");
    	buf.append("Amount:").append(amount).append(" ");
    	
    	return buf.toString();
    }
    
    public int hasCode() {
    	return toString().hashCode();
    }
}
