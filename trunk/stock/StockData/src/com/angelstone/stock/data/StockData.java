package com.angelstone.stock.data;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.TreeMap;

public class StockData {
	public String id = null;

	public TreeMap<Integer, Double> DividendMap = new TreeMap<Integer, Double>();
	public TreeMap<Integer, DayData> DayDataMap = new TreeMap<Integer, DayData>();
	public TreeMap<Integer, TreeMap<Integer, FiveMinData>> FiveMinDataMap = new TreeMap<Integer, TreeMap<Integer, FiveMinData>>();

	public String path = null;

	public StockData(String id, String path) {
		this.id = id;
		this.path = path;
	}

	public void LoadData() throws IOException {
		if (id == null || path == null) {
			throw new IOException("Invalid Stock Data: Path=" + path + ",ID="
					+ id);
		}

		// Read day data
		String dayDataFileName = genDayDataFileName();

		FileInputStream fis = new FileInputStream(dayDataFileName);

		int available = 0;
		
		while ((available = fis.available()) > 0) {
			
			if (available > 0) {
				DayData data = new DayData();
				data.read(fis);
	
				DayDataMap.put(Integer.valueOf(data.date), data);
			}
		}

		fis.close();

		// Read 5 minutes data
		String fiveMinDataFileName = genFiveMinDataFileName();

		fis = new FileInputStream(fiveMinDataFileName);

		while (fis.available() > 0) {
			FiveMinData data = new FiveMinData();
			data.read(fis);

			if (FiveMinDataMap.containsKey(Integer.valueOf(data.date))) {
				TreeMap<Integer, FiveMinData> map = FiveMinDataMap.get(Integer
						.valueOf(data.date));

				map.put(Integer.valueOf(data.time), data);
			} else {
				TreeMap<Integer, FiveMinData> map = new TreeMap<Integer, FiveMinData>();
				map.put(Integer.valueOf(data.time), data);
				FiveMinDataMap.put(Integer.valueOf(data.date), map);
			}
		}

		fis.close();
	}

	private String genFiveMinDataFileName() {
		StringBuffer buf = new StringBuffer(100);

		buf.append(path).append(File.separatorChar);
		buf.append(id.substring(0, 2)).append(File.separatorChar);
		buf.append("fzline").append(File.separatorChar);
		buf.append(id).append(".lc5");

		return buf.toString().trim();
	}

	private String genDayDataFileName() {
		StringBuffer buf = new StringBuffer(100);

		buf.append(path).append(File.separatorChar);
		buf.append(id.substring(0, 2)).append(File.separatorChar);
		buf.append("lday").append(File.separatorChar);
		buf.append(id).append(".day");

		return buf.toString().trim();
	}

	public static StockData LoadStockData(String id, String path)
			throws IOException {
		StockData data = new StockData(id, path);

		data.LoadData();

		return data;
	}

	private static void usage() {
		System.err.println("Usage: StockData -id [StockId] -path [StockDataPath] -five -lday");
		System.err.println("-five: show five minutes data");
		System.err.println("-lday: show lday data");
	}
	
	public static void main(String[] args) throws IOException {
		String id = null;
		String path = null;
		boolean showFiveMinute = false;
		boolean showlDay = false;
		
		for(int i = 0; i < args.length; i++) {
			if ("-id".equalsIgnoreCase(args[i])) {
				if (++i < args.length) {
					id = args[i];
				}
			} else if ("-path".equalsIgnoreCase(args[i])) {
				if (++i < args.length) {
					path = args[i];
				}
			} else if ("-five".equalsIgnoreCase(args[i])) {
				showFiveMinute = true;
			} else if ("-lday".equalsIgnoreCase(args[i])) {
				showlDay = true;
			} else if ("-h".equalsIgnoreCase(args[i]) || "/?".equalsIgnoreCase(args[i])) {
				usage();
				
				return;
			}
		}
		
		if (id == null || path == null) {
			usage();
			
			return;
		}
		
		if (id.length() == 0 || path.length() == 0) {
			usage();
			
			return;
		}
		
		StockData data = StockData.LoadStockData(id,
				path);
		
		System.out.println("StockId:" + id);
		System.out.println("lDayCount:" + data.DayDataMap.size());
		
		if (showlDay) {
			for(Integer key : data.DayDataMap.keySet()) {
				DayData dData = data.DayDataMap.get(key);
				
				System.out.println(dData);
			}
		}
		
		System.out.println("FiveMinuteCount:" + data.FiveMinDataMap.size());
		if (showFiveMinute) {
			for(Integer key : data.FiveMinDataMap.keySet()) {
				TreeMap<Integer, FiveMinData> fDataMap = data.FiveMinDataMap.get(key);
				
				for(FiveMinData fData : fDataMap.values()) {
					System.out.println(fData);
				}
			}
		}
	}
}
