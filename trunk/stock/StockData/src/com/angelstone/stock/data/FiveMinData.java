package com.angelstone.stock.data;

import java.io.IOException;
import java.io.InputStream;

import com.angelstone.stock.io.StockDataReader;

public class FiveMinData {
	public short date = 0;
	public short time = 0;
	
	public int month = 0;
	public int day = 0;
	public int hour = 0;
	public int minute = 0;
	public float b_low;
	public float b_high;
	public float s_low;
	public float s_high;
	public float amount;
	public float[] reserved = new float[2];

	public FiveMinData() {

	}

	public void read(InputStream is) throws IOException {
		date = StockDataReader.readShort(is);
		time = StockDataReader.readShort(is);
		b_low = StockDataReader.readFloat(is);
		b_high = StockDataReader.readFloat(is);
		s_low = StockDataReader.readFloat(is);
		s_high = StockDataReader.readFloat(is);
		amount = StockDataReader.readFloat(is);
		reserved[0] = StockDataReader.readFloat(is);
		reserved[1] = StockDataReader.readFloat(is);

		month = (date & 0xFFFF) / 100;
		day = (date & 0xFFFF) % 100;
		hour = (time & 0xFFFF) / 60;
		minute = (time & 0xFFFF) % 60;
	}

	public String toString() {
		StringBuffer buf = new StringBuffer(100);

		buf.append("FiveMinute ");
		buf.append("DateTime:").append(month).append(" ");
		buf.append(day).append(" ");
		buf.append(hour).append(":").append(minute).append(" ");
		buf.append("Buy:").append(b_low).append("-").append(b_high).append(" ");
		buf.append("Sale:").append(s_low).append("-").append(s_high)
				.append(" ");
		buf.append("Amount:").append(amount);

		return buf.toString().trim();
	}

	public int hashCode() {
		return toString().hashCode();
	}
}
