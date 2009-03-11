package com.angelstone.stock.io;

import java.io.IOException;
import java.io.InputStream;

public class StockDataReader {
	
	private StockDataReader() {
		
	}
	
	public static int readInt(InputStream is) throws IOException{
		byte[] buf = new byte[4];
		
		int count = is.read(buf);
		
		if (count != 4) {
			throw new IOException("Not enough data, need 4 but read " + count);
		}
		
		int i = (buf[3] & 0xFF) << 24 |
			(buf[2] & 0xFF)  << 16 |
			(buf[1] & 0xFF)  << 8 |
			(buf[0] & 0xFF) ;
		
		i = i & 0xFFFFFFFF;
		
		return i;
	}
	
	public static float readFloat(InputStream is) throws IOException{
		int i = readInt(is);
		
		float f = Float.intBitsToFloat(i);
		
		return f;
	}
	
	public static short readShort(InputStream is) throws IOException{
		byte[] buf = new byte[2];
		
		int count = is.read(buf);
		
		if (count != 2) {
			throw new IOException("Not enough data, need 2 but read " + count);
		}
		
		int i = (buf[1] & 0xFF) << 8 |
			(buf[0] & 0xFF);
		
		short s = (short)(i & 0x0000FFFF);
		
		return s;
	}
}
