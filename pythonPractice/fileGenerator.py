import csv
import random
from datetime import datetime, timedelta

# -----------------------------
# CONFIGURATION
# -----------------------------
NUM_FILES = 10
MIN_ROWS = 1_000_000
MAX_ROWS = 1_500_000
OUTPUT_FOLDER = "generated_csvs/"   # Change if desired

# -----------------------------
# DATA SOURCES
# -----------------------------
regions = ["North", "South", "East", "West"]
products = [
    ("Notebook", "Stationery", 2.5),
    ("Pen", "Stationery", 0.8),
    ("Highlighter", "Stationery", 1.2),
    ("Desk Chair", "Furniture", 75),
    ("Office Desk", "Furniture", 220),
    ("Laptop", "Electronics", 899),
    ("Mouse", "Electronics", 15),
    ("Monitor", "Electronics", 150),
    ("Printer", "Electronics", 199),
    ("Desk Lamp", "Office Supplies", 18),
    ("Whiteboard", "Office Supplies", 60),
]
start_date = datetime(2024, 1, 1)

# -----------------------------
# SCRIPT
# -----------------------------
import os
os.makedirs(OUTPUT_FOLDER, exist_ok=True)

for file_index in range(NUM_FILES):
    row_count = random.randint(MIN_ROWS, MAX_ROWS)
    filename = f"{OUTPUT_FOLDER}sales_data_{file_index+1}.csv"

    print(f"Generating {filename} with {row_count:,} rows...")

    with open(filename, "w", newline="") as f:
        writer = csv.writer(f)
        writer.writerow([
            "TransactionID","Date","Region","Product","Category",
            "Quantity","UnitPrice","TotalSale"
        ])

        for i in range(row_count):
            transaction_id = file_index * 10_000_000 + i + 1
            date = start_date + timedelta(days=random.randint(0, 180))
            region = random.choice(regions)
            product, category, unit_price = random.choice(products)
            quantity = random.randint(1, 50)
            total_sale = round(quantity * unit_price, 2)

            writer.writerow([
                transaction_id,
                date.strftime("%Y-%m-%d"),
                region,
                product,
                category,
                quantity,
                unit_price,
                total_sale
            ])

    print(f"Finished {filename}")

print("\nAll CSV files generated successfully!")

