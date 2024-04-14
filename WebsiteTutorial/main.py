# Run by "py main.py"

from website import create_app

app = create_app()

if __name__ == '__main__':
    # Debug == true means that it will rerun when code changes.
    app.run(debug=True)
