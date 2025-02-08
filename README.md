# Image 2 ASCII

The **Image to ASCII Converter** is a tool that transforms images into ASCII art. ASCII art is a graphic design technique that uses printable characters from the ASCII standard to create visual representations. This tool allows users to upload an image, apply various filters (such as contrast, brightness, grayscale, and more), and convert the image into a text-based representation using ASCII characters. The resulting ASCII art can be copied to the clipboard or saved as an image or text file.

## How Does It Work?

### 1. Image Loading

- Users can upload an image by clicking the "Upload" button or dragging and dropping an image file into the application window.
- Supported image formats include `.jpg`, `.jpeg`, `.png` and `.bmp`.
- Once an image is loaded, it is displayed in the application for preview.

### 2. Image Preprocessing

- The image is preprocessed to prepare it for ASCII conversion. This includes resizing the image to fit the desired output dimensions based on the size of the ASCII characters.
- The preprocessing step ensures that the image is scaled appropriately to maintain its proportions when converted to ASCII art.

### 3. Filter Adjustments

Users can apply various filters to the image to adjust its appearance before conversion:

- **Contrast**: Adjusts the difference between light and dark areas.
- **Brightness**: Increases or decreases the overall lightness of the image.
- **Grayscale**: Converts the image to grayscale, removing color information.
- **Invert**: Inverts the colors of the image.
- **Sepia**: Applies a sepia tone to the image (currently under development).

These adjustments are made using trackbars, and the changes are applied in real-time.

### 4. ASCII Conversion

- The image is converted into ASCII art by mapping each pixel's brightness to a corresponding ASCII character.
- A predefined set of characters (e.g., `@`, `#`, `S`, `%`, `?`, `*`, `+`, `;`, `:`, `,`, `.`, `'`) is used, with each character representing a different level of brightness.
- The brightness of each pixel is calculated using the formula:

    ```
    Gray = 0.299 * R + 0.587 * G + 0.114 * B
    ```

    where **R**, **G**, and **B** are the red, green, and blue components of the pixel's color.

- The resulting ASCII characters are arranged in a grid to form the final ASCII art.

## Example Images
Here are some example images to demonstrate the capabilities of the Image to ASCII Converter:

![image](https://github.com/user-attachments/assets/aa3e60a1-1c06-4dad-85b7-9121f910652f)
![image](https://github.com/user-attachments/assets/5345ba27-49fe-476d-84de-b7288d66aa48)
![AsciiArt](https://github.com/user-attachments/assets/1a5582ed-4707-4fc5-beab-13a1f99520ed)
