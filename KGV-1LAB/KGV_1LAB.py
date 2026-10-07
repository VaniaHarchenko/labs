import os
import math
from PIL import Image, ImageEnhance

def convert_formats():
    """Завдання 1: Конвертація форматів зображень (пакетна обробка)"""
    print("\n--- КОНВЕРТАЦІЯ ФОРМАТІВ ---")
    paths_input = input("Уведіть назви/шляхи зображень через кому (наприклад, img1.jpg, img2.png): ")
    paths = [p.strip().strip("'\"") for p in paths_input.split(',') if p.strip()]
    
    target_format = input("Уведіть вихідний формат (png, jpeg, bmp, webp): ").strip().lower()
    save_dir = input("Уведіть шлях до папки для збереження (натисніть Enter для поточної): ").strip().strip("'\"")
    
    if save_dir and not os.path.exists(save_dir):
        os.makedirs(save_dir)
        
    for path in paths:
        try:
            old_size = os.path.getsize(path)
            with Image.open(path) as img:
                base_name = os.path.splitext(os.path.basename(path))[0]
                
                # Обробка формату JPEG (не підтримує альфа-канал RGBA)
                fmt_save = 'JPEG' if target_format in ['jpg', 'jpeg'] else target_format.upper()
                new_filename = f"{base_name}.{target_format}"
                new_path = os.path.join(save_dir, new_filename) if save_dir else new_filename
                
                if fmt_save == 'JPEG' and img.mode in ('RGBA', 'LA', 'P'):
                    img = img.convert('RGB')
                
                img.save(new_path, format=fmt_save)
                
                new_size = os.path.getsize(new_path)
                print(f" {base_name} збережено як {new_path}")
                print(f"  Розмір до: {old_size / 1024:.2f} KB | Розмір після: {new_size / 1024:.2f} KB")
        except Exception as e:
            print(f" Помилка при обробці '{path}': {e}")

def resize_images():
    """Завдання 2: Зміна розміру зображень зі збереженням пропорцій"""
    print("\n--- ЗМІНА РОЗМІРУ ЗОБРАЖЕНЬ ---")
    paths_input = input("Уведіть назву файлу: ")
    paths = [p.strip().strip("'\"") for p in paths_input.split(',') if p.strip()]
    
    try:
        target_pixels = int(input("Уведіть бажане значення більшої сторони (у пікселях): ").strip())
        if target_pixels <= 0:
            print("Кількість пікселів має бути більше 0!")
            return
    except ValueError:
        print("Помилка: введіть ціле число.")
        return
        
    save_dir = input("Папка для збереження (натисніть Enter для поточної): ").strip().strip("'\"")
    if save_dir and not os.path.exists(save_dir):
        os.makedirs(save_dir)
        
    for path in paths:
        try:
            with Image.open(path) as img:
                orig_w, orig_h = img.size
                
                # Розрахунок пропорційного розміру за більшою стороною
                if orig_w >= orig_h:
                    w = target_pixels
                    h = max(1, int(orig_h * (target_pixels / orig_w)))
                else:
                    h = target_pixels
                    w = max(1, int(orig_w * (target_pixels / orig_h)))
                
                # Використання інтерполяції LANCZOS для високої якості
                resized_img = img.resize((w, h), Image.Resampling.LANCZOS)
                
                base_name = os.path.splitext(os.path.basename(path))[0]
                ext = os.path.splitext(path)[1]
                new_path = os.path.join(save_dir, f"{base_name}_resized{ext}") if save_dir else f"{base_name}_resized{ext}"
                
                resized_img.save(new_path)
                print(f"✓ {base_name}: змінено з {orig_w}x{orig_h} px на {w}x{h} px")
        except Exception as e:
            print(f"✗ Помилка при обробці '{path}': {e}")

def replace_colour():
    """Завдання 3: Перетворення/заміна кольору пікселів"""
    print("\n--- ПЕРЕТВОРЕННЯ КОЛЬОРІВ ---")
    path = input("Уведіть назву файлу: ").strip().strip("'\"")
    
    try:
        print("Уведіть RGB колір для заміни (наприклад, 255 255 255): ")
        target_r, target_g, target_b = map(int, input().split())
        
        print("Уведіть новий RGB колір (наприклад, 255 0 0): ")
        new_r, new_g, new_b = map(int, input().split())
        
        tolerance = int(input("Уведіть допустиму похибку кольору (0 - точний збіг, 30-50 - для відтінків): "))
        
        save_dir = input("Папка для збереження (натисніть Enter для поточної): ").strip().strip("'\"")
        if save_dir and not os.path.exists(save_dir):
            os.makedirs(save_dir)
        
        with Image.open(path) as img:
            img = img.convert("RGBA")
            data = img.getdata()
            
            new_data = []
            for item in data:
                # Обчислення евклідової відстані між кольорами у 3D RGB просторі
                distance = math.sqrt((item[0] - target_r)**2 + (item[1] - target_g)**2 + (item[2] - target_b)**2)
                
                if distance <= tolerance:
                    new_data.append((new_r, new_g, new_b, item[3]))
                else:
                    new_data.append(item)
                    
            img.putdata(new_data)
            
            base_name = os.path.splitext(os.path.basename(path))[0]
            new_filename = f"{base_name}_color_replaced.png"
            new_path = os.path.join(save_dir, new_filename) if save_dir else new_filename
            
            img.save(new_path)
            print(f" Колір успішно замінено. Збережено у {new_path}")
            
    except Exception as e:
        print(f" Помилка: {e}")
            
    except Exception as e:
        print(f" Помилка: {e}")

def color_balance():
    """Завдання 4: Корекція колірного балансу та яскравості"""
    print("\n--- КОРЕКЦІЯ КОЛІРНОГО БАЛАНСУ ---")
    path = input("Уведіть шлях до зображення: ").strip().strip("'\"")
    
    print("Оберіть тип корекції:")
    print("1. Червоний канал (Red)")
    print("2. Зелений канал (Green)")
    print("3. Синій канал (Blue)")
    print("4. Загальна яскравість (Brightness)")
    choice = input("Ваш вибір (1-4): ").strip()
    
    try:
        factor = float(input("Уведіть коефіцієнт (наприклад, 1.5 для збільшення на 50%, 0.7 для зменшення): "))
        
        with Image.open(path) as img:
            if img.mode != 'RGB':
                img = img.convert('RGB')
                
            if choice == '4':
                enhancer = ImageEnhance.Brightness(img)
                result_img = enhancer.enhance(factor)
            elif choice in ['1', '2', '3']:
                r, g, b = img.split()
                
                # Обмеження діапазону 0..255 для запобігання переповненню
                if choice == '1':
                    r = r.point(lambda p: min(255, max(0, int(p * factor))))
                elif choice == '2':
                    g = g.point(lambda p: min(255, max(0, int(p * factor))))
                elif choice == '3':
                    b = b.point(lambda p: min(255, max(0, int(p * factor))))
                    
                result_img = Image.merge('RGB', (r, g, b))
            else:
                print("Невірний вибір.")
                return
                
            base_name, ext = os.path.splitext(path)
            new_path = f"{base_name}_balanced{ext}"
            result_img.save(new_path)
            print(f" Колірний баланс скориговано. Збережено як {new_path}")
    except Exception as e:
        print(f" Помилка: {e}")

def main():
    while True:
        print("\n================ МЕНЮ ================")
        print("1 – Конвертація форматів зображень")
        print("2 – Зміна розміру зображень (Resize)")
        print("3 – Перетворення кольорів (Color Replace)")
        print("4 – Корекція колірного балансу (Color Balance)")
        print("0 – Вихід")
        print("=======================================")
        
        choice = input("Оберіть дію (0-4): ").strip()
        
        if choice == '1':
            convert_formats()
        elif choice == '2':
            resize_images()
        elif choice == '3':
            replace_colour()
        elif choice == '4':
            color_balance()
        elif choice == '0':
            print("Роботу програми завершено.")
            break
        else:
            print("Некоректний вибір. Введіть число від 0 до 4.")

if __name__ == "__main__":
    main()
